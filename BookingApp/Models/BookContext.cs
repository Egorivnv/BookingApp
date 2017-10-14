using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace BookingApp.Models
{
    public class BookContext: DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Manager> Managers { get; set; }
    }

    public class ManagerBdInit : DropCreateDatabaseAlways<BookContext>
    {
        protected override void Seed(BookContext context)
        {
            context.Managers.Add(new Manager { Name = "Alex", Age = 30, Experience = 3 });
            context.Managers.Add(new Manager { Name = "Tom", Age = 29, Experience = 5 });
            context.Books.Add(new Models.Book { Name = "AAA", Author = "BBB", Price = 5 });
            context.Books.Add(new Models.Book { Name = "QQQ", Author = "WWW", Price = 10 });
            base.Seed(context);
        }
    }
}