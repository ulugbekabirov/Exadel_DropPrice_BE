using System.Collections.Generic;

namespace DAL.DbInitializer
{
    class RoleNames
    {
        public const string Admin = "Admin";
        public const string Moderator = "Moderator";
        public const string User = "User";

        public static IEnumerable<string> GetRolesOfAdmin()
        {
            return new string[] { Admin, Moderator, User };
        }

        public static IEnumerable<string> GetRolesOfModerator()
        {
            return new string[] { Moderator, User };
        }

        public static IEnumerable<string> GetRolesOfUser()
        {
            return new string[] { User };
        }
    }
}
