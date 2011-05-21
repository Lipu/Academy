using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SharpArch.Core;

namespace XAIL.ApplicationServices.Security
{
    public class UserRegistrationRequest
    {
        public UserRegistrationRequest(string email, string username, string password, bool isApproved = true)
        {
            Email = email;
            Username = username;
            Password = password;
            IsApproved = isApproved;
        }

        public string Email { get; set; }

        public string Username { get; set; }

        public string Password { get; set; }

        public bool IsApproved { get; set; }

        public bool IsValid
        {
            get
            {
                return (!string.IsNullOrEmpty(Email) && Email.Trim() != string.Empty
                    && !string.IsNullOrEmpty(Username) && Username.Trim() != string.Empty);
            }
        }
    }
}
