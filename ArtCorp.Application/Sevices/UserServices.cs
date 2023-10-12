using ArtCorp.Application.DTO.Request;
using ArtCorp.Application.DTO.Response;
using ArtCorp.Application.Sevices.Interfaces;
using ArtCorp.Domain.Interfaces.SPI;

namespace ArtCorp.Application.Sevices
{
    public class UserServices : IUserServices
    {
        private IUserPersistencePort _userServices;
        public UserServices(IUserPersistencePort userServicesPort)
        {
            _userServices = userServicesPort;
        }

        public Task<UserResponse> CreateUser(UserRequest userRequest, string identityRoleId)
        {
            throw new NotImplementedException();
        }

        public Task<UserResponse?> GetUser(string email, string password)
        {
            throw new NotImplementedException();
        }
    }
}
