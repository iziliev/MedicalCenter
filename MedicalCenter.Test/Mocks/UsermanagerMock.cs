using MedicalCenter.Infrastructure.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCenter.Test.Mocks
{
    public class UsermanagerMock
    {
        public static UserManager<User> CreateUserManager()
        {
            Mock<IUserPasswordStore<User>> userPasswordStore = new Mock<IUserPasswordStore<User>>();
            userPasswordStore.Setup(s => s.CreateAsync(It.IsAny<User>(), It.IsAny<CancellationToken>()))
                .Returns(Task.FromResult(IdentityResult.Success));

            var options = new Mock<IOptions<IdentityOptions>>();
            var idOptions = new IdentityOptions();

            //this should be keep in sync with settings in ConfigureIdentity in WebApi -> Startup.cs
            idOptions.Lockout.AllowedForNewUsers = false;
            idOptions.Password.RequireDigit = true;
            idOptions.Password.RequireLowercase = true;
            idOptions.Password.RequireNonAlphanumeric = true;
            idOptions.Password.RequireUppercase = true;
            idOptions.Password.RequiredLength = 6;
            idOptions.Password.RequiredUniqueChars = 1;

            idOptions.SignIn.RequireConfirmedEmail = false;

            // Lockout settings.
            idOptions.Lockout.DefaultLockoutTimeSpan = TimeSpan.FromMinutes(5);
            idOptions.Lockout.MaxFailedAccessAttempts = 5;
            idOptions.Lockout.AllowedForNewUsers = true;


            options.Setup(o => o.Value).Returns(idOptions);
            var userValidators = new List<IUserValidator<User>>();
            UserValidator<User> validator = new UserValidator<User>();
            userValidators.Add(validator);

            var passValidator = new PasswordValidator<User>();
            var pwdValidators = new List<IPasswordValidator<User>>();
            pwdValidators.Add(passValidator);
            var userManager = new UserManager<User>(userPasswordStore.Object, options.Object, new PasswordHasher<User>(),
                null, pwdValidators, new UpperInvariantLookupNormalizer(),
                new IdentityErrorDescriber(), null,
                new Mock<ILogger<UserManager<User>>>().Object);

            return userManager;
        }
    }
}
