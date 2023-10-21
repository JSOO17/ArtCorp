using ArtCorp.Application.Sevices;
using ArtCorp.Domain.Interfaces.API;
using ArtCorp.Domain.Models;
using ArtCorp.Domain.Utils;
using Moq;
using System.Reflection;

namespace ArtCorp.Application.Tests.Services
{
    [TestClass]
    public class UserServicesTests
    {
        [TestMethod]
        public async Task GetUser_SuccessfullAsync()
        {
            var mockUserUsecases= new Mock<IUserUsecases>();

            var userServices = new UserServices(mockUserUsecases.Object);

            mockUserUsecases
                .Setup(p => p.GetUser(It.IsAny<LoginModel>()))
                .ReturnsAsync(new UserModel()
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

            var userReponse = await userServices.GetUser("pepito@gmail.com", "pass");

            Assert.IsNotNull(userReponse);
            Assert.AreEqual("Pepito", userReponse.Names);
            Assert.AreEqual("Perezz", userReponse.Lastnames);
            Assert.AreEqual("3314", userReponse.Document);
            Assert.AreEqual("image.png", userReponse.Avatar);
            Assert.AreEqual(TypesDocument.CedulaExtranjeria, userReponse.TypeDocument);
            Assert.AreEqual("+341341", userReponse.Cellphone);
            Assert.AreEqual("user@gmail.com", userReponse.Email);
            Assert.AreEqual("ff", userReponse.Password);
            Assert.AreEqual(2, userReponse.RoleId);
        }
    }
}