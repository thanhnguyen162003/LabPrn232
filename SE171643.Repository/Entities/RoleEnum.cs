namespace SE171643.Repository.Entities;

public enum RoleEnum
{
    Administrator = 1,
    Moderator = 2,
    Developer = 3,
    Member = 4
}

public static class RoleEnumExtensions
{
    public static string? GetRoleName(this RoleEnum role)
    {
        return role switch
        {
            RoleEnum.Administrator => "administrator",
            RoleEnum.Moderator => "moderator",
            RoleEnum.Developer => "developer",
            RoleEnum.Member => "member",
            _ => null
        };
    }
} 