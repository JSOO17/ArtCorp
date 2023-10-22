using ArtCorp.Domain.Exceptions;
using ArtCorp.Domain.Interfaces.SPI;
using ArtCorp.Domain.Models;
using ArtCorp.Domain.Usecases;
using ArtCorp.Domain.Utils;
using Moq;

namespace ArtCorp.Domain.Tests.UserUsecases
{
    [TestClass]
    public class UserUsecasesTests
    {
        [TestMethod]
        public async Task GetUser_Succesfull()
        {
            var login = new LoginModel
            {
                Email = "pepito@gmail.com",
                Password = "password"
            };

            var mockUserPersistence = new Mock<IUserPersistencePort>();
            var mockUserEncrypt = new Mock<IUserEncryptPort>();

            mockUserEncrypt
                .Setup(p => p.Verify(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(true);

            mockUserPersistence
                .Setup(p => p.GetUser(It.IsAny<string>()))
                .ReturnsAsync(new UserModel
                {
                    Names = "Pepito",
                    Lastnames = "Perezz",
                    Document = "3314",
                    Avatar = "image.png",
                    TypeDocument = "CE",
                    Username = "pepitoyaki",
                    Cellphone = "+341341",
                    Email = "user@gmail.com",
                    Password = "ff",
                    RoleId = 2,
                    Birthday = DateTime.Parse("2023-02-23"),
                    DateCreated = DateTime.Parse("2023-10-23")
                });

            var useCases = new Usecases.UserUsecases(mockUserPersistence.Object, mockUserEncrypt.Object);

            var model = await useCases.GetUser(login);

            Assert.IsNotNull(model);
            Assert.AreEqual("Pepito", model.Names);
            Assert.AreEqual("Perezz", model.Lastnames);
            Assert.AreEqual("3314", model.Document);
            Assert.AreEqual("image.png", model.Avatar);
            Assert.AreEqual("CE", model.TypeDocument);
            Assert.AreEqual("+341341", model.Cellphone);
            Assert.AreEqual("user@gmail.com", model.Email);
            Assert.AreEqual("ff", model.Password);
            Assert.AreEqual(2, model.RoleId);
            Assert.AreEqual(DateTime.Parse("2023-02-23"), model.Birthday);
            Assert.AreEqual(DateTime.Parse("2023-10-23"), model.DateCreated);
        }

        [TestMethod]
        public async Task GetUser_ArgumentNull()
        {
            var mockUserPersistence = new Mock<IUserPersistencePort>();
            var mockUserEncrypt = new Mock<IUserEncryptPort>();

            var useCases = new Usecases.UserUsecases(mockUserPersistence.Object, mockUserEncrypt.Object);

            var e = await Assert.ThrowsExceptionAsync<ArgumentNullException>(async () =>
            {
                await useCases.GetUser(null);
            });

            Assert.IsNotNull(e);
        }

        [TestMethod]
        public async Task GetUser_InvalidLoginEmailIncorrect()
        {
            var login = new LoginModel
            {
                Email = "pepito@gmail.com",
                Password = "password"
            };

            var mockUserPersistence = new Mock<IUserPersistencePort>();
            var mockUserEncrypt = new Mock<IUserEncryptPort>();

            mockUserEncrypt
               .Setup(p => p.Verify(It.IsAny<string>(), It.IsAny<string>()))
               .Returns(true);

            mockUserPersistence
                .Setup(p => p.GetUser(It.IsAny<string>()))
                .ReturnsAsync((string email) => null);

            var useCases = new Usecases.UserUsecases(mockUserPersistence.Object, mockUserEncrypt.Object);

            var e = await Assert.ThrowsExceptionAsync<InvalidLoginException>(async () =>
            {
                await useCases.GetUser(login);
            });

            Assert.IsNotNull(e);
            Assert.AreEqual("Email is incorrect", e.Message);
            Assert.AreEqual("pepito@gmail.com", e.Login.Email);
            Assert.AreEqual("password", e.Login.Password);
        }

        [TestMethod]
        public async Task GetUser_InvalidLoginPasswordIncorrect()
        {
            var login = new LoginModel
            {
                Email = "pepito@gmail.com",
                Password = "password"
            };

            var mockUserPersistence = new Mock<IUserPersistencePort>();
            var mockUserEncrypt = new Mock<IUserEncryptPort>();

            mockUserEncrypt
                .Setup(p => p.Verify(It.IsAny<string>(), It.IsAny<string>()))
                .Returns(false);

            mockUserPersistence
                .Setup(p => p.GetUser(It.IsAny<string>()))
                .ReturnsAsync(new UserModel
                {
                    Names = "Pepito",
                    Lastnames = "Perezz",
                    Document = "3314",
                    Avatar = "image.png",
                    TypeDocument = TypesDocument.CedulaExtranjeria,
                    Username = "pepitoyaki",
                    Cellphone = "+341341",
                    Email = "user@gmail.com",
                    Password = "ff",
                    RoleId = 2
                });

            var useCases = new Usecases.UserUsecases(mockUserPersistence.Object, mockUserEncrypt.Object);

            var e = await Assert.ThrowsExceptionAsync<InvalidLoginException>(async () =>
            {
                await useCases.GetUser(login);
            });

            Assert.IsNotNull(e);
            Assert.AreEqual("Password is incorrect", e.Message);
            Assert.AreEqual("pepito@gmail.com", e.Login.Email);
            Assert.AreEqual("password", e.Login.Password);
        }
    }
}