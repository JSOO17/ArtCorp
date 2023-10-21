using ArtCorp.Domain.Interfaces.SPI;
using ArtCorp.Domain.Models;
using ArtCorp.Infrastructure.Data.Models;

namespace ArtCorp.Infrastructure.Data.Adapter
{
    public class UserAdapter : IUserPersistencePort
    {
        private readonly ArtPortContext _context;
        public UserAdapter(ArtPortContext context)
        {
            _context = context;
        }

        public Task CreateUser(UserModel userModel)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel?> GetUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel?> GetUser(string email)
        {
            throw new NotImplementedException();
        }
    }
}
