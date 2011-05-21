using Paging;
using XAIL.Core.Security;

namespace XAIL.ApplicationServices.Security
{
    public interface IUserService 
    {
        User GetUserById(int id);
        
        User GetUserByUsername(string username);
        
        User GetUserByEmail(string email);
        
        IPagedList<User> GetUsers(string email, string username, int pageIndex, int pageSize);
        
        bool ValidateUser(string usernameOrEmail, string password);
        
        UserRegistrationResult RegisterUser(UserRegistrationRequest request);
        
        //PasswordChangeResult ChangePassword(ChangePasswordRequest request);
        
        void SetEmail(User user, string newEmail);
        
        void SetUsername(User user, string newUsername);
    }
}
