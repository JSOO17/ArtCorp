using ArtCorp.Domain.Utils;
using ArtCorp.Infrastructure.Data.Adapter;
using ArtCorp.Infrastructure.Data.Models;

namespace ArtCorp.Infrastructure.Data.Tests.Adapter
{
    [TestClass]
    public class UserAdapterTests
    {
        private ArtPortContext _context;

        public UserAdapterTests()
        {
            _context = DbContextPrepare.Setup();
        }

        [TestMethod]
        public async void GetUserSuccessfull()
        {
            await DbContextPrepare.SeedDatabase(_context);

            var adapter = new UserAdapter(_context);

            var user = await adapter.GetUser("takoyaki@gmail.com");

            Assert.IsNotNull(user);
            Assert.AreEqual(1, user.Id);
            Assert.AreEqual("Pepito", user.Names);
            Assert.AreEqual("Perezz", user.Lastnames);
            Assert.AreEqual("Takoyaki", user.Username);
            Assert.AreEqual("takoyaki@gmail.com", user.Email);
            Assert.AreEqual("volcano", user.Password);
            Assert.AreEqual("+12313", user.Cellphone);
            Assert.AreEqual(TypesDocument.Cedula, user.TypeDocument);
            Assert.AreEqual("img.png", user.Avatar);
            Assert.AreEqual("341331", user.Document);
            Assert.AreEqual(2, user.RoleId);
        }

        [TestMethod]
        public async void GetUserNull()
        {
            await DbContextPrepare.SeedDatabase(_context);

            var adapter = new UserAdapter(_context);

            var user = await adapter.GetUser("nulopa@gmail.com");

            Assert.IsNull(user);
        }
    }
}
