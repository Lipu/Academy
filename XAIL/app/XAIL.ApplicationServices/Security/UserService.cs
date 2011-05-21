using System;
using Paging;
using SharpArch.Core.PersistenceSupport;
using XAIL.Core.Security;

namespace XAIL.ApplicationServices.Security
{
    public class UserService : IUserService
    {
        private readonly IEncryptionService encryptionService;
        private readonly IRepository<User> userRepository;        
        
        public UserService(IEncryptionService encryptionService, IRepository<User> userRepository)
        {
            this.encryptionService = encryptionService;
            this.userRepository = userRepository;
        }
        
        public User GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public User GetUserByUsername(string username)
        {
            throw new NotImplementedException();
        }

        public User GetUserByEmail(string email)
        {
            throw new NotImplementedException();
        }

        public IPagedList<User> GetUsers(string email, string username, int pageIndex, int pageSize)
        {
            throw new NotImplementedException();
        }

        public bool ValidateUser(string usernameOrEmail, string password)
        {
            throw new NotImplementedException();
        }

        public UserRegistrationResult RegisterUser(UserRegistrationRequest request)
        {
            throw new NotImplementedException();
        }

        public void SetEmail(User user, string newEmail)
        {
            throw new NotImplementedException();
        }

        public void SetUsername(User user, string newUsername)
        {
            throw new NotImplementedException();
        }
    }
}
