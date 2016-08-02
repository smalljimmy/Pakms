using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.Collections.ObjectModel;
using PaK_v1._0.Models;


namespace PaK_v1._0.Interfaces
{
    public interface IAuthenticationService
    {
        User AuthenticateUser(string username, string password);
        string CalculateHash(string clearTextPassword, string salt);
    }

    public class AuthenticationService : IAuthenticationService
    {
        private PaKEntities _pakdb;
        private ObservableCollection<users> _users;

        private class InternalUserData
        {
            public InternalUserData(string username, string email, string hashedPassword, string[] roles)
            {
                Username = username;
                Email = email;
                HashedPassword = hashedPassword;
                Roles = roles;
            }

            public string Username
            {
                get;
                private set;
            }
 
            public string Email
            {
                get;
                private set;
            }
 
            public string HashedPassword
            {
                get;
                private set;
            }
 
            public string[] Roles
            {
                get;
                private set;
            }
        }

        /*
        private static readonly List<InternalUserData> _users = new List<InternalUserData>() 
        { 
            new InternalUserData("Mark", "mark@company.com", 
            "MB5PYIsbI2YzCUe34Q5ZU2VferIoI4Ttd+ydolWV0OE=", new string[] { "Administrators" }), 
            new InternalUserData("John", "john@company.com", 
            "hMaLizwzOQ5LeOnMuj+C6W75Zl5CXXYbwDSHWW9ZOXc=", new string[] { })
        };
 
        public User AuthenticateUser(string username, string clearTextPassword)
        {
            InternalUserData userData = _users.FirstOrDefault(u => u.Username.Equals(username) 
                && u.HashedPassword.Equals(CalculateHash(clearTextPassword, u.Username)));
            if (userData == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");
 
            return new User(userData.Username, userData.Email, userData.Roles);
        } */

        public User AuthenticateUser(string username, string clearTextPassword)
        {
            users usrdata = new users();
            _pakdb = new PaKEntities();
            _users = new ObservableCollection<users>(_pakdb.users);
            usrdata = _users.FirstOrDefault(u => u.usr_name.ToLower().Equals(username.ToLower())
                && u.usr_passwd.Equals(CalculateHash(clearTextPassword, u.usr_name)));
            if (usrdata == null)
                throw new UnauthorizedAccessException("Access denied. Please provide some valid credentials.");


            return new User(usrdata.usr_id, usrdata.usr_name, usrdata.usr_mobilephone, usrdata.roles.role_key, usrdata.theme, usrdata.fontsize, usrdata.color);
        }

 
        public string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }

    public class User
    {
        public User(int userId, string username, string email, string role, string theme, string fontsize, string color)
        {
            UserId = userId;
            Username = username;
            Email = email;
            Role = role;
            Theme = theme;
            Fontsize = fontsize;
            Color = color;
        }

        public int UserId
        {
            get;
            set;
        }

        public string Username
        {
            get;
            set;
        }

        public string Email
        {
            get;
            set;
        }

        public string Role
        {
            get;
            set;
        }

        public string Theme
        {
            get;
            set;
        }

        public string Fontsize
        {
            get;
            set;
        }

        public string Color
        {
            get;
            set;
        }
    }


}
