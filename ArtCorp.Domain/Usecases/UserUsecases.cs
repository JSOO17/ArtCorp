using ArtCorp.Domain.Exceptions;
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

        public async Task<UserModel> GetUser(LoginModel login)
        {
            if (login == null)
            {
                throw new ArgumentNullException("Login can not be null.");
            };

            var user = await _userPersistencePort.GetUser(login.Email) ?? throw new InvalidLoginException("Email is incorrect", login);

            if (!_userEncryptPort.Verify(login.Password, user.Password))
            {
                throw new InvalidLoginException("Password is incorrect", login);
            };

            return user;
        }
    }
}
