using ArtCorp.Domain.Models;

namespace ArtCorp.Domain.Interfaces.SPI
{
    public interface IUserPersistencePort
    {
        void CreateUser(UserModel userModel);
        Task<UserModel?> GetUser(int id);
        Task<UserModel?> GetUser(string email);
    }
}
