using backend.context;
using backend.Controllers.AuthController.Models;
using backend.Services.AuthService;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace backend.Controllers.AuthController;

[Route("/api/v1/auth")]
public class AuthController(IAuthService authService, CubeDbContext cubeDbContext) : ControllerBase
{
    [HttpGet("nonce")]
    public async Task<Guid> GenerateNonce()
    {
        Guid nonce;

        do { nonce = Guid.NewGuid(); } 
        while (await cubeDbContext.Nonces.FirstOrDefaultAsync(n => n.Id == nonce) != null);

        return nonce;
    }
   
    [HttpPost("login")]
    public async Task<LoginResponse> Login([FromBody] LoginRequest loginRequest)
    {
        return await authService.HandleLogin(loginRequest);
    } 
}