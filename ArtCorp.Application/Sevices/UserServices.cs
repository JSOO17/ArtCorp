using ArtCorp.Application.DTO.Request;
using ArtCorp.Application.DTO.Response;
using ArtCorp.Application.Sevices.Interfaces;
using ArtCorp.Domain.Interfaces.API;

namespace ArtCorp.Application.Sevices
{
    public class UserServices : IUserServices
    {
        private IUserUsecases _userUsecases;
        public UserServices(IUserUsecases userUsecases)
        {
            _userUsecases = userUsecases;
        }

        public async Task<UserResponse> CreateUser(UserRequest userRequest, string identityRoleId)
        {
            return null;
        }

        public async Task<UserResponse?> GetUser(string email, string password)
        {
            return null;
        }
    }
}
