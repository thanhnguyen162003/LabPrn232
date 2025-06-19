using SE171643.Repository.Abstractions;
using SE171643.Service.Abstractions;
using SE171643.Service.Models;
using SE171643.Service.Security;

public class AuthService(ISystemAccountRepository accountRepo, JwtHelper jwtHelper) : IAuthService
{
    public async Task<AuthResult> LoginAsync(string email, string password)
    {
        if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
        {
            return new AuthResult { Success = false, ErrorCode = "HB40001", ErrorMessage = "Email and password are required" };
        }
        var user = await accountRepo.ValidateCredentials(email, password);
        if (user == null)
        {
            return new AuthResult { Success = false, ErrorCode = "HB40101", ErrorMessage = "Invalid email or password" };
        }
        var roleName = user.RoleName;
        if (!jwtHelper.IsAllowedRole(roleName))
        {
            return new AuthResult { Success = false, ErrorCode = "HB40301", ErrorMessage = "Permission denied" };
        }
        var token = jwtHelper.GenerateJwtToken(user, roleName!);
        return new AuthResult { Success = true, Token = token, Role = roleName };
    }
} 