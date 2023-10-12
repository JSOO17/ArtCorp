using ArtCorp.Domain.Interfaces.API;
using ArtCorp.Domain.Interfaces.SPI;
using ArtCorp.Domain.Models;

namespace ArtCorp.Domain.Usecases
{
    public class UserUsecases : IUserUsecases
    {
        private readonly IUserPersistencePort _userPersistencePort;
        private readonly IUserEncryptPort _userEncryptPort;

        public UserUsecases(IUserPersistencePort userPersistencePort, IUserEncryptPort userEncryptPort)
        {
            _userPersistencePort = userPersistencePort;
            _userEncryptPort = userEncryptPort;
        }

        public Task<UserModel?> GetUser(string email)
        {
            throw new NotImplementedException();
        }

        public Task<UserModel> GetUser(LoginModel login)
        {
            throw new NotImplementedException();
        }
    }
}
