using IdentityServer3.Core.Services;
using IdentityServer3.Core.Validation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OAuth2._0Service.Models
{
    class CustomGrantValidator : ICustomGrantValidator
    {
        private IUserService _users;

        public CustomGrantValidator(IUserService users)
        {
            _users = users;
        }

         Task<CustomGrantValidationResult> ICustomGrantValidator.ValidateAsync(ValidatedTokenRequest request)
        {
            var param = request.Raw.Get("some_custom_parameter");
            if (string.IsNullOrWhiteSpace(param))
            {
                return Task.FromResult<CustomGrantValidationResult>(
                    new CustomGrantValidationResult("Missing parameters."));
            }

            return Task.FromResult(new CustomGrantValidationResult("bob", "customGrant"));
        }

        public string GrantType
        {
            get { return "custom"; }
        }
    }
}