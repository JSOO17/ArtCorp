using ArtCorp.Application.DTO.Request;
using ArtCorp.Application.DTO.Response;

namespace ArtCorp.Application.Sevices.Interfaces
{
    public interface IUserServices
    {
        Task<UserResponse> CreateUser(UserRequest userRequest, string identityRoleId);
        Task<UserResponse> GetUser(string email, string password);
    }
}
