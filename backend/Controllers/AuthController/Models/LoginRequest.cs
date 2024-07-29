namespace backend.Controllers.AuthController.Models;

public record LoginRequest(string Email, string Password, Guid Nonce);