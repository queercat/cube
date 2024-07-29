using System.Security;
using System.Security.Cryptography;
using System.Text;
using backend.context;
using backend.Controllers.AuthController.Models;
using backend.entities;
using backend.Services.EncryptionService;
using Isopoh.Cryptography.Argon2;
using Microsoft.EntityFrameworkCore;
namespace backend.Services.AuthService;

public class AuthService(CubeDbContext cubeDbContext, IEncryptionService encryptionService, IConfiguration configuration) : IAuthService
{
    public async Task<bool> ValidatePassword(Guid userId, string password)
    {
        var user = await cubeDbContext.Users.FirstOrDefaultAsync(u => u.Id == userId);
        
        if (user is null) throw new ArgumentException($"Unable to find user {userId}");

        var storedHash = user.Password;
        var salt = user.Salt;

        return Argon2.Verify(storedHash, $"{password}:{salt}");
    }
    
    public async Task<(LoginResponse loginResponse, Guid sessionId)> HandleLogin(LoginRequest request)
    {
        if (!await CheckNonce(request.Nonce))
        {
            return (new LoginResponse(false), new Guid());
        }

        var user = await cubeDbContext.Users.FirstOrDefaultAsync(u => u.EmailAddress == request.Email.ToLower());

        if (user is null) throw new ArgumentException($"Unable to find user with email {request.Email}");

        var rawPassword = encryptionService.Decrypt(request.Password, request.Nonce.ToString());

        if (!await ValidatePassword(user.Id, rawPassword)) return (new LoginResponse(false), new Guid());

        var userSession = new UserSession()
        {
            User = user,
            CreationDate = DateTime.UtcNow,
            ExpirationDate = DateTime.UtcNow + TimeSpan.FromHours(int.Parse(configuration["SessionDurationInHours"] ?? throw new InvalidOperationException()))
        };
        
        cubeDbContext.UserSessions.Add(userSession);

        await cubeDbContext.SaveChangesAsync();

        return (new LoginResponse(true), userSession.Id);
    }

    public async Task<bool> CheckNonce(Guid nonce)
    {
        if (await IsNonceUsed(nonce)) return false;

        await BurnNonce(nonce);

        return true;
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