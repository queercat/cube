using backend.Services.EncryptionService;

namespace Backend.Tests;

public class EncryptionTests
{
    private EncryptionService _encryptionService = new();

    [Test]
    public void EncryptionService_WithDataAndKey_ReturnsEncryptedData()
    {
        var data = "hunter2";
        var secret = Guid.NewGuid().ToString();
        var encryptedData = _encryptionService.Encrypt(data, secret);

        Assert.That(encryptedData, Is.Not.EqualTo(data));

        var decryptedData = _encryptionService.Decrypt(encryptedData, secret);

        Assert.That(decryptedData, Is.EqualTo(data));
    }
}