using IdentityServer3.Core.Models;
using IdentityServer3.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Web;

namespace OAuth2_0AuthorizationServer.Models
{
    public class CustomUserService : IUserService
    {
        public Task AuthenticateExternalAsync(ExternalAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        // This method is called during the token issuance to validate the user's credentials
        public Task AuthenticateLocalAsync(LocalAuthenticationContext context)
        {
            // Validate the user's credentials (e.g., check against a database)
            bool isValid = ValidateUser(context.UserName, context.Password);

            if (isValid)
            {
                // Set the subject ID and authentication method
                context.AuthenticateResult = new AuthenticateResult(
                    context.UserName,
                    context.UserName,
                    new List<Claim>
                    {
                    new Claim("sub", context.UserName),
                        // Add other claims as needed
                    });
            }
            else
            {
                // Invalid credentials
                context.AuthenticateResult = new AuthenticateResult("Invalid credentials");
            }

            return Task.CompletedTask;
        }

        // This method is called to retrieve claims for the user
        public Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            // Retrieve claims for the user (e.g., from a database)
            // Add claims to the context
            // ...

            return Task.CompletedTask;
        }

        // This method is called to determine if the user is active
        public Task IsActiveAsync(IsActiveContext context)
        {
            // Check if the user is active (e.g., not locked out or disabled)
            context.IsActive = true;

            return Task.CompletedTask;
        }

        public Task PostAuthenticateAsync(PostAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task PreAuthenticateAsync(PreAuthenticationContext context)
        {
            throw new NotImplementedException();
        }

        public Task SignOutAsync(SignOutContext context)
        {
            throw new NotImplementedException();
        }

        // Dummy method for user validation (replace this with actual validation logic)
        private bool ValidateUser(string username, string password)
        {
            // Replace this with actual user validation logic
            return username == "demo" && password == "password";
        }
    }
}