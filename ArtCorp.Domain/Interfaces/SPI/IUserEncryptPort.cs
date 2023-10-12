namespace ArtCorp.Domain.Interfaces.SPI
{
    public interface IUserEncryptPort
    {
        string Encode(string password);

        bool Verify(string password, string hashPassword);
    }
}
