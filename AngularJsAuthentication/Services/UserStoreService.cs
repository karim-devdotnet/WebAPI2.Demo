using AngularJsAuthentication.Models;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;

namespace AngularJsAuthentication.Services
{
    public class UserStoreService
          : IUserStore<AppUser>, IUserPasswordStore<AppUser>
    {
        Auth2Context context = new Auth2Context();

        public Task CreateAsync(AppUser user)
        {
            try
            {
                context.AppUserSet.Add(user);
                return context.SaveChangesAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public Task DeleteAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByIdAsync(string userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> FindByNameAsync(string userName)
        {
            Task<AppUser> task = context.AppUserSet.Where(
                                  apu => apu.AppUserName == userName)
                                  .FirstOrDefaultAsync();

            return task;
        }

        public Task<AppUser> FindAsync(string userName, string password)
        {
            Task<AppUser> task = context.AppUserSet.Where(
                                  apu => apu.AppUserName == userName &&
                                  apu.AppPassword == password)
                                  .FirstOrDefaultAsync();

            return task;
        }

        public Task UpdateAsync(AppUser user)
        {
            throw new NotImplementedException();
        }

        public void Dispose()
        {
            context.Dispose();
        }

        public Task<string> GetPasswordHashAsync(AppUser user)
        {
            if (user == null)
            {
                throw new ArgumentNullException("user");
            }

            return Task.FromResult(user.AppPassword);
        }

        public Task<bool> HasPasswordAsync(AppUser user)
        {
            return Task.FromResult(user.AppPassword != null);
        }

        public Task SetPasswordHashAsync(AppUser user, string passwordHash)
        {
            return Task.FromResult(0);
        }

    }

    public class MyPasswordHasher : IPasswordHasher
    {
        public string HashPassword(string password)
        {
            return password;
        }

        public PasswordVerificationResult VerifyHashedPassword
                      (string hashedPassword, string providedPassword)
        {
            if (hashedPassword == HashPassword(providedPassword))
                return PasswordVerificationResult.Success;
            else
                return PasswordVerificationResult.Failed;
        }
    }
}