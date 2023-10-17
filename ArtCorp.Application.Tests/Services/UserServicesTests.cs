using ArtCorp.Application.Sevices;
using ArtCorp.Domain.Interfaces.API;
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
            var mockUserUsecases= new Mock<IUserUsecases>();

            var userServices = new UserServices(mockUserUsecases.Object);

            mockUserUsecases
                .Setup(p => p.GetUser(It.IsAny<LoginModel>()))
                .ReturnsAsync(new UserModel()
                {
                    Name = "Pepito",
                    Lastname = "Perezz",
                    DNI = 3314,
                    Cellphone = "+341341",
                    Email = "user@gmail.com",
                    Password = "fajgrnvia",
                    RoleId = 2
                });

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