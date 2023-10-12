using ArtCorp.Application.Sevices;
using ArtCorp.Domain.Interfaces.SPI;
using ArtCorp.Domain.Models;
using Moq;

namespace ArtCorp.Application.Tests.Services
{
    [TestClass]
    public class UserServicesTests
    {
        [TestMethod]
        public async Task GetUser_SuccessfullAsync()
        {
            var mockUserPersistence = new Mock<IUserPersistencePort>();

            var userServices = new UserServices(mockUserPersistence.Object);

            mockUserPersistence
                .Setup(p => p.GetUser(It.IsAny<string>()))
                .Returns(Task.FromResult<UserModel?>(new UserModel()
                {
                    Name = "Pepito",
                    Lastname = "Perezz",
                    DNI = 3314,
                    Cellphone = "+341341",
                    Email = "user@gmail.com",
                    Password = "fajgrnvia",
                    RoleId = 2
                }));

            var userReponse = await userServices.GetUser("pepito@gmail.com", "pass");

            Assert.IsNotNull(userReponse);
            Assert.AreEqual("Pepito", userReponse.Name);
            Assert.AreEqual("Perezz", userReponse.Lastname);
            Assert.AreEqual("user@gmail.com", userReponse.Email);
            Assert.AreEqual("fajgrnvia", userReponse.Password);
            Assert.AreEqual("+341341", userReponse.Cellphone);
            Assert.AreEqual(3314, userReponse.DNI);
            Assert.AreEqual(2, userReponse.RoleId);
        }
    }
}