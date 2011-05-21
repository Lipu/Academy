using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Validator.Constraints;
using SharpArch.Core;
using SharpArch.Core.DomainModel;

namespace XAIL.Core.Security
{
    public class User : Entity
    {
        public User() { }

        public User(string username, string email)
        {
            Check.Require(!string.IsNullOrEmpty(username) && username.Trim() != String.Empty, "user name must be provided");
            Check.Require(!string.IsNullOrEmpty(email) && email.Trim() != String.Empty, "email must be provided");
            Username = username;
            Email = email;
            CreatedOnUtc = DateTime.UtcNow;
        }

        public virtual string Username { get; set; }

        [DomainSignature]
        [NotNullNotEmpty(Message = "Email must be provided")]
        public virtual string Email { get; set; }

        [NotNullNotEmpty(Message = "Password must be provided")]
        public virtual string Password { get; set; }

        public virtual string PasswordSalt { get; set; }

        public virtual bool IsApproved { get; set; }

        public virtual DateTime CreatedOnUtc { get; set; }

        public virtual DateTime? LastLoginDateUtc { get; set; }

        public virtual DateTime? LastPasswordChangeDateUtc { get; set; }

        public virtual int FailedPasswordAttemptCount { get; set; }
    }
}
