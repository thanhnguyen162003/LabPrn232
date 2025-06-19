
namespace SE171643.Service.Models
{
    public class AuthResult
    {
        public bool Success { get; set; }
        public string? Token { get; set; }
        public string? Role { get; set; }
        public string? ErrorCode { get; set; }
        public string? ErrorMessage { get; set; }
    }

}
