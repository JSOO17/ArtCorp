using ArtCorp.Domain.Models;

namespace ArtCorp.Domain.Interfaces.API
{
    public interface IUserUsecases
    {
        Task<UserModel> GetUser(LoginModel login);
    }
}
