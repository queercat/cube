using System.Buffers.Text;
using System.Security.Cryptography;
using System.Text;
using Isopoh.Cryptography.Argon2;
using Org.BouncyCastle.Crypto;
using Org.BouncyCastle.Crypto.Digests;
using Org.BouncyCastle.Crypto.Engines;
using Org.BouncyCastle.Crypto.Macs;
using Org.BouncyCastle.Crypto.Modes;
using Org.BouncyCastle.Crypto.Paddings;
using Org.BouncyCastle.Crypto.Parameters;
using Org.BouncyCastle.Crypto.Prng;
using Org.BouncyCastle.Security;

namespace backend.Services.EncryptionService;

public class EncryptionService : IEncryptionService
{
    public static byte[] GetSecureRandomBytes()
    {
        SecureRandom defaultSecureRandom = new SecureRandom();
        byte[] bytes = new byte[16];
        defaultSecureRandom.NextBytes(bytes);
        return bytes;
    }
    
    static byte[] EncryptStringToBytes_Aes(string plainText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException("plainText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");
            byte[] encrypted;

            // Create an Aes object
            // with the specified key and IV.
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Create an encryptor to perform the stream transform.
            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for encryption.
            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        //Write all data to the stream.
                        swEncrypt.Write(plainText);
                    }
                    encrypted = msEncrypt.ToArray();
                }
            }

            // Return the encrypted bytes from the memory stream.
            return encrypted;
        }

        static string DecryptStringFromBytes_Aes(byte[] cipherText, byte[] key, byte[] iv)
        {
            // Check arguments.
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException("cipherText");
            if (key == null || key.Length <= 0)
                throw new ArgumentNullException("key");
            if (iv == null || iv.Length <= 0)
                throw new ArgumentNullException("iv");

            // Declare the string used to hold
            // the decrypted text.
            string plaintext = null;

            // Create an Aes object
            // with the specified key and IV.
            using Aes aesAlg = Aes.Create();
            aesAlg.Key = key;
            aesAlg.IV = iv;

            // Create a decryptor to perform the stream transform.
            ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

            // Create the streams used for decryption.
            using (MemoryStream msDecrypt = new MemoryStream(cipherText))
            {
                using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                {
                    using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                    {

                        // Read the decrypted bytes from the decrypting stream
                        // and place them in a string.
                        plaintext = srDecrypt.ReadToEnd();
                    }
                }
            }

            return plaintext;
        }
    

    public string Encrypt(string data, string key)
    {
        var hashedKey = SHA256.HashData(Encoding.UTF8.GetBytes(key));
        var iv = GetSecureRandomBytes();
        
        var cipherBytes = EncryptStringToBytes_Aes(data, hashedKey, iv);

        return $"{Convert.ToBase64String(cipherBytes)}:{Convert.ToBase64String(iv)}";
    }
    
    public string Decrypt(string data, string key)
    {
        var hashedKey = SHA256.HashData(Encoding.UTF8.GetBytes(key));
        var segments = data.Split(":");
        
        var cipherText = Convert.FromBase64String(segments[0]);
        var iv = Convert.FromBase64String(segments[1]);
        
        var plainText = DecryptStringFromBytes_Aes(cipherText, hashedKey, iv);

        return plainText;
    }

    public string HashPassword(string password)
    {
        return Argon2.Hash(password);
    }
}