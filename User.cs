using System;
using System.Collections.Generic;
using System.Linq;

namespace NavigationWithPages
{
    public class Users
    {
        private readonly List<User> _users = new List<User>();

        public void Add(User user)
        {
            _users.Add(user);
        }

        public bool Exists(string username)
        {
            return _users.Any(u => String.Equals(u.Username, username));
        }

        public bool Login(string username, string password)
        {
            return _users.Any(u => String.Equals(u.Username, username) && String.Equals(u.Password, password));
        }
    }

    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
    }
}