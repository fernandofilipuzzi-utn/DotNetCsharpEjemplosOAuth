using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace OAuth2_0AuthorizationServer.Models
{
    public class MealUserManager
    {
        private readonly UserManager<User> _userManager;

        public MealUserManager(UserManager<User> userManager)
        {
            _userManager = userManager;
        }

        public async Task<bool> CheckPassword(User user, string password)
        {
            return await _userManager.CheckPasswordAsync(user, password);
        }

        public IList<string> GetRoles(string userId)
        {
            return _userManager.GetRolesAsync(userId).Result;
        }
    }
}