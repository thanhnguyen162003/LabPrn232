using SE171643.Service.Models;

namespace SE171643.Service.Abstractions;

public interface IAuthService
{
    Task<AuthResult> LoginAsync(string email, string password);
} 