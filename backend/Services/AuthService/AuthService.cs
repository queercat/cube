using System.Security.Cryptography;
using System.Text;
using backend.context;
using backend.Controllers.AuthController.Models;
using backend.entities;
using Microsoft.EntityFrameworkCore;
using Org.BouncyCastle.Crypto.Engines;

namespace backend.Services.AuthService;

public class AuthService(CubeDbContext cubeDbContext) : IAuthService
{
    public async Task<LoginResponse> HandleLogin(LoginRequest request)
    {
        if (!await CheckNonce(request.Nonce))
        {
            return new LoginResponse(false, null);
        }
        
        

        return new LoginResponse(true, null);
    }

    public async Task<bool> CheckNonce(Guid nonce)
    {
        if (await IsNonceUsed(nonce)) return false;

        await BurnNonce(nonce);

        return true;
    }

    private string HashPassword(Guid userId, Guid userId, string password, Guid nonce)
    {
        var passwordBytes = Encoding.UTF8.GetBytes(password);

        using (var aes = Aes.Create())
        {
            
        }
        
    }

    private async Task<bool> IsNonceUsed(Guid nonce)
    {
        return await cubeDbContext.Nonces.FirstOrDefaultAsync(n => n.Id == nonce) != null;
    }

    private async Task<Guid> BurnNonce(Guid nonce)
    {
        cubeDbContext.Nonces.Add(new Nonce() { Id = nonce });
        await cubeDbContext.SaveChangesAsync();

        return nonce;
    }
}