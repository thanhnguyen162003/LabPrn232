
namespace SE171643.Service.Models.AuthModels
{
    public record LoginRequest
    {
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
