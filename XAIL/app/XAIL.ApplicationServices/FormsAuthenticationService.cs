using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Security;
using XAIL.ApplicationServices.Security;
using XAIL.Core.Security;

namespace XAIL.ApplicationServices
{
    public class FormsAuthenticationService : IAuthenticationService
    {
        private readonly HttpContextBase httpContext;
        private readonly IUserService userService;
        private User cachedUser;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="httpContext">HTTP context</param>
        /// <param name="userService">User service</param>
        /// <param name="userSettings">User settings</param>
        public FormsAuthenticationService(HttpContextBase httpContext, IUserService userService)
        {
            this.httpContext = httpContext;
            this.userService = userService;
            ExpirationTimeSpan = TimeSpan.FromHours(6);
        }

        public TimeSpan ExpirationTimeSpan { get; set; }
        
        public void SignIn(User user, bool createPersistentCookie)
        {
            var now = DateTime.Now.ToLocalTime();

            var ticket = new FormsAuthenticationTicket(
                1 /*version*/,
                user.Email,
                now,
                now.Add(ExpirationTimeSpan),
                createPersistentCookie,
                user.Email,
                FormsAuthentication.FormsCookiePath);

            var encryptedTicket = FormsAuthentication.Encrypt(ticket);

            var cookie = new HttpCookie(FormsAuthentication.FormsCookieName, encryptedTicket);
            cookie.HttpOnly = true;
            cookie.Secure = FormsAuthentication.RequireSSL;
            cookie.Path = FormsAuthentication.FormsCookiePath;
            if (FormsAuthentication.CookieDomain != null)
            {
                cookie.Domain = FormsAuthentication.CookieDomain;
            }

            httpContext.Response.Cookies.Add(cookie);
            cachedUser = user;
        }

        public void SignOut()
        {
            cachedUser = null;
            FormsAuthentication.SignOut();
        }

        public User GetAuthenticatedUser()
        {
            if (cachedUser != null)
                return cachedUser;

            if (httpContext == null ||
                httpContext.Request == null ||
                !httpContext.Request.IsAuthenticated ||
                !(httpContext.User.Identity is FormsIdentity))
            {
                return null;
            }

            var formsIdentity = (FormsIdentity)httpContext.User.Identity;
            var usernameOrEmail = formsIdentity.Ticket.UserData;

            if (String.IsNullOrWhiteSpace(usernameOrEmail))
                return null;
            var user = userService.GetUserByEmail(usernameOrEmail);
            if (user != null && user.IsApproved)
                cachedUser = user;
            return cachedUser;
        }
    }
}
