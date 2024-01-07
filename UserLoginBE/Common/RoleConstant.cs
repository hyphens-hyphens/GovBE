namespace UserLoginBE.Common
{
    public class RoleConstant
    {
        public const string AdminWard = "AdminWard";
        public const string AdminGov = "AdminGov";
        public const string AdminDistrict = "AdminDistrict";
        public const string User = "User";
        public const string Guest = "Guest";

        public static readonly List<string> ListRoles = new()
        {
            AdminWard,
            AdminGov,
            AdminDistrict,
            User,
            Guest
        };
    }
}
