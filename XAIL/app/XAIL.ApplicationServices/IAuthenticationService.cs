using XAIL.Core.Security;

namespace XAIL.ApplicationServices
{
    public interface IAuthenticationService
    {
        void SignIn(User user, bool createPersistentCookie);
        
        void SignOut();

        User GetAuthenticatedUser();
    }
}
