using AngularJsAuthentication.Models;
using AngularJsAuthentication.Services;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AngularJsAuthentication.Repositories
{
    public class Auth2Repository:IDisposable
    {
        //private Auth2Context _ctx;

        private UserManager<AppUser> _userManager;

        public Auth2Repository()
        {
            //_ctx = new Auth2Context();
            _userManager = new UserManager<AppUser>(new UserStoreService()) { PasswordHasher = new MyPasswordHasher() };
        }

        public async Task<IdentityResult> RegisterUser(UserModel userModel)
        {
            AppUser user = new AppUser
            {
                AppUserName = userModel.UserName,
                AppPassword = userModel.Password
            };

            var result = await _userManager.CreateAsync(user, userModel.Password);

            return result;
        }
        

        public async Task<AppUser> FindUser(string userName, string password)
        {
            AppUser user = await _userManager.FindAsync(userName, password);

            return user;
        }

        public void Dispose()
        {
            //_ctx.Dispose();
            _userManager.Dispose();

        }
    }
}