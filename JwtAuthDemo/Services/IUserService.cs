namespace JwtAuthDemo.Services
{
    public interface IUserService
    {
        bool IsAnExistingUser(string userName);
        bool IsValidUserCredentials(string userName, string password);
        string GetUserRole(string userName);
        void StoreUser(User user);
        User GetUser(string userName);
    }

    public class User
    {
        public string Name { get; set; }
        public string Username { get; set; }
        public string HashedPassword { get; set; }
        public Roles[] Roles { get; set; }
    }

    public class Roles
    {
        public string Name { get; set; }
        public string[] Permissions { get; set; }
    }
}