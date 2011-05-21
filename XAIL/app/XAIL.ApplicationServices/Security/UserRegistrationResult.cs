using System.Collections.Generic;
using XAIL.Core.Security;

namespace XAIL.ApplicationServices.Security
{
    public class UserRegistrationResult
    {
        public User User { get; set; }
        public IList<string> Errors { get; set; }

        public UserRegistrationResult()
        {
            this.Errors = new List<string>();
        }

        public bool Success
        {
            get { return (this.User != null) && (this.Errors.Count == 0); }
        }

        public void AddError(string error)
        {
            this.Errors.Add(error);
        }
    }
}
