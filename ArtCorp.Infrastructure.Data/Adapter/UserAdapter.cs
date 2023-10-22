using ArtCorp.Domain.Interfaces.SPI;
using ArtCorp.Domain.Models;
using ArtCorp.Infrastructure.Data.Mappers;
using ArtCorp.Infrastructure.Data.Models;
using Microsoft.EntityFrameworkCore;

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

        public async Task<UserModel?> GetUser(string email)
        {
            var user = await _context.Users
                            .Where(user => user.Email == email)
                            .FirstOrDefaultAsync();

            return user == null ? null : UserMapper.ToUserModel(user);
        }
    }
}
