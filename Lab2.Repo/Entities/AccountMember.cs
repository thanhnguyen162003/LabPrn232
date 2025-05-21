
namespace Prn232.Lab2.Entities;

public class AccountMember
{
    public int MemberId { get; set; }
    public required string MemberPassword { get; set; }
    public required string FullName { get; set; }
    public required string Email { get; set; }
    public required string MemberRole { get; set; }
}
