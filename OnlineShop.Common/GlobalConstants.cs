namespace OnlineShop.Common
{
    public static class GlobalConstants
    {
        public const string SystemName = "OnlineShop";

        public const int UsernameMinLength = 5;
        public const int UsernameMaxLength = 30;

        public const int FirstNameMinLength = 1;
        public const int FirstNameMaxLength = 30;

        public const int LastNameMinLength = 1;
        public const int LastNameMaxLength = 30;

        public const int PasswordMinLength = 8;
        public const int PasswordMaxLength = 20; 

        public static class Roles
        {
            public const string AdministratorRoleName = "Administrator";
            public const string UserRoleName = "User";
        }
    }
}
