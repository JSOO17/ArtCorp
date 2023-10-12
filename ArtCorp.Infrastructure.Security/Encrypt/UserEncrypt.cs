using ArtCorp.Domain.Interfaces.SPI;

namespace ArtCorp.Infrastructure.Security.Encrypt
{
    public class UserEncrypt : IUserEncryptPort
    {
        public string Encode(string password)
        {
            return string.Empty;
        }

        public bool Verify(string password, string hashPassword)
        {
            return false;
        }
    }
}
