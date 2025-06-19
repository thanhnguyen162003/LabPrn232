
namespace SE171643.Service.Models.AuthModels
{
    public record LoginResponse
    {
        public required string Token { get; set; }
        public required string Role { get; set; }
    }
}
