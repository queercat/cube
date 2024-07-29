using backend.Controllers.AuthController.Models;

namespace backend.Services.AuthService;

public interface IAuthService
{
    public Task<LoginResponse> HandleLogin(LoginRequest request);
}