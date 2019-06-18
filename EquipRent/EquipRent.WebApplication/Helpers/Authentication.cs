using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using NHibernate.AspNet.Identity;
using EquipRent.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EquipRent.WebApplication.Helpers
{
    public class AuthenticationUserManager : UserManager<ApplicationUser>
    {
        public AuthenticationUserManager(IUserStore<ApplicationUser> store) : base(store)
        {
            // Configure validation logic for usernames
            UserValidator = new UserValidator<ApplicationUser>(this)
            {
                AllowOnlyAlphanumericUserNames = false,
                RequireUniqueEmail = true
            };

            // Configure validation logic for passwords
            PasswordValidator = new PasswordValidator
            {
                RequiredLength = 6,
                RequireDigit = true,
                RequireLowercase = true
            };

            // Configure user lockout defaults
            UserLockoutEnabledByDefault = true;
            DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
            MaxFailedAccessAttemptsBeforeLockout = 5;
        }
    }

    public class AuthenticationSignInManager : SignInManager<ApplicationUser, string>
    {
        public AuthenticationSignInManager(AuthenticationUserManager userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {
        }
    }

    public class AuthenticationRoleManager : RoleManager<IdentityRole>
    {
        public AuthenticationRoleManager(IRoleStore<IdentityRole, string> roleStore)
            : base(roleStore)
        {
        }
    }
}