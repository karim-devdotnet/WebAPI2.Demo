using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace BookService.Models
{
    public class BookServiceContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public BookServiceContext() : base("BookServiceContext")
        {
            //To trace the SQL queries that EF generates
            this.Database.Log = s => System.Diagnostics.Debug.WriteLine(s);
        }

        public System.Data.Entity.DbSet<BookService.Models.Author> Authors { get; set; }

        public System.Data.Entity.DbSet<BookService.Models.Book> Books { get; set; }
    }
}
//https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework
//> Enable-Mitgrations
//> Add-Migration -connectionString ""
//> Update-Database -connectionString ""

//https://docs.microsoft.com/en-us/aspnet/web-api/overview/data/using-web-api-with-entity-framework/part-4
//There are three ways to load related data in Entity Framework: eager loading, lazy loading, and explicit loading. 
//1. Eager Loading
//With eager loading, EF loads related entities as part of the initial database query.To perform eager loading, use the System.Data.Entity.Include extension method.


