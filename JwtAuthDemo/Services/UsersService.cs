using System.Collections.Generic;
using System.Linq;
using JwtAuthDemo.Infrastructure;
using Microsoft.Extensions.Logging;

namespace JwtAuthDemo.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger<UserService> _logger;

        private List<User> _users = new List<User>();


        // inject your database here for user validation
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;

            _users.Add(new User
            {
                Name = "TestUser1",
                Username = "test1",
                HashedPassword = "password1",
                Roles = new Roles[]
                {
                    new Roles
                    {
                        Name = UserRoles.BasicUser,
                        Permissions = new []{Permissions.UsersPermitions.Create, Permissions.UsersPermitions.Edit}
                    }
                }

            });
            
            _users.Add(new User
            {
                Name = "TestUser2",
                Username = "test2",
                HashedPassword = "password2",
                Roles = new Roles[]
                {
                    new Roles
                    {
                        Name = UserRoles.BasicUser,
                        Permissions = new []{Permissions.UsersPermitions.Create, Permissions.UsersPermitions.Edit}
                    }
                }

            });
            
            _users.Add(new User
            {
                Name = "TestUser2",
                Username = "admin",
                HashedPassword = "securePassword",
                Roles = new Roles[]
                {
                    new Roles
                    {
                        Name = UserRoles.Admin,
                        Permissions = new []{Permissions.UsersPermitions.Create, Permissions.UsersPermitions.Edit, Permissions.UsersPermitions.Delete, Permissions.UsersPermitions.View}
                    }
                }

            });
        }

        public bool IsValidUserCredentials(string userName, string password)
        {
            _logger.LogInformation($"Validating user [{userName}]");
            if (string.IsNullOrWhiteSpace(userName))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(password))
            {
                return false;
            }

            return _users.Any(_ => _.Username.Equals(userName) && _.HashedPassword.Equals(password));
        }

        public bool IsAnExistingUser(string userName)
        {
            return _users.Any(_ => _.Username.Equals(userName));
        }

        public string GetUserRole(string userName)
        {
            if (!IsAnExistingUser(userName))
            {
                return string.Empty;
            }

            if (userName == "admin")
            {
                return UserRoles.Admin;
            }

            return UserRoles.BasicUser;
        }

        public void StoreUser(User user)
        {
            throw new System.NotImplementedException();
        }

        public User GetUser(string userName)
        {
            throw new System.NotImplementedException();
        }
    }
}
