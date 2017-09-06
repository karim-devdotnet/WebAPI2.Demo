using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AngularJsAuthentication.Models
{
    public class Auth2Context:DbContext
    {
        public Auth2Context()
            :base("Auth2Context")
        {

        }

        public  DbSet<AppUser> AppUserSet { get; set; }
    }

    public class AppUser : IUser
    {
        public AppUser()
        {
            AppUserId = Guid.NewGuid();
            Id = AppUserId.ToString();
        }

        //Existing database fields
        public Guid AppUserId { get; set; }
        public string AppUserName { get; set; }
        public string AppPassword { get; set; }

        [NotMapped]
        public virtual string Id { get; set; }

        [NotMapped]
        public string UserName
        {
            get
            {
                return AppUserName;
            }
            set
            {
                AppUserName = value;
            }
        }
    }
}