using System.Collections.Generic;
using System.Linq;
using ApiAuth.Models;

namespace ApiAuth.Repository
{
    public static class UserRepository{

        private static IList<User> _users;

        static UserRepository() => 
            _users = new List<User>{
                new(){Id = 1, Username = "batman", Password = "batman", Role = "manager"},
                new(){Id = 1, Username = "yansantos", Password = "123", Role = "manager"},
                new(){Id = 1, Username = "joao", Password = "123", Role = "employee"}
            };
        
        public static IEnumerable<User> GetUsers() => _users;
        
        public static User GetUser(string username, string password) =>
            _users.FirstOrDefault(
                u => u.Username == username
                && u.Password == password
            );
    }
}