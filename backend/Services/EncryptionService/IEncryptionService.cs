using System.Security;

namespace backend.Services.EncryptionService;

public interface IEncryptionService
{
    public string Encrypt(string data, string key);
    public string Decrypt(string data, string key);

    public string HashPassword(string password);
}