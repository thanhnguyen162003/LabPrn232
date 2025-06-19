using Microsoft.AspNetCore.Mvc;
using SE171643.Service.Abstractions;
using SE171643.Service.Models.AuthModels;
using SE171643.Service.Security;

namespace SE171643.API.Controllers;


public record LoginResponse(string Token, string Role);

[ApiController]
[Route("api/auth")]
public class AuthController(IAuthService authService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> Login([FromBody] LoginRequest request)
    {
        var result = await authService.LoginAsync(request.Email, request.Password);
        if (!result.Success)
        {
            return result.ErrorCode switch
            {
                "HB40001" => BadRequest(new ErrorResponse(result.ErrorCode, result.ErrorMessage!)),
                "HB40101" => Unauthorized(new ErrorResponse(result.ErrorCode, result.ErrorMessage!)),
                "HB40301" => StatusCode(403, new ErrorResponse(result.ErrorCode, result.ErrorMessage!)),
                _ => StatusCode(500, new ErrorResponse("HB50001", result.ErrorMessage ?? "Internal server error"))
            };
        }
        return Ok(new LoginResponse(result.Token!, result.Role!));
    }
}
