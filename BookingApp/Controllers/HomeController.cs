using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BookingApp.Models;

namespace BookingApp.Controllers
{
    public class HomeController : Controller
    {
        BookContext db = new BookContext();
        public ActionResult Index()
        {
            ViewBag.Books = db.Books;
            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.BookId = id;
            return View();
        }
        [HttpPost]
        public ActionResult Buy(Purchase purchase)
        {
            purchase.Date = DateTime.Now;
            db.Purchases.Add(purchase);
            db.SaveChanges();
            return View("BuyRez", purchase);
        }

        [HttpGet]
        public ActionResult NewBook ()
        {
            return View();
        }

        [HttpPost]
        public ActionResult NewBook(Book book, Manager manager, string surname)
        {
            if (!ModelState.IsValid) return View();
            manager.Name = "";
            foreach (var man in db.Managers)
            {
                if (man.ManagerId == manager.ManagerId) manager.Name = man.Name;
            }
            if (string.IsNullOrWhiteSpace(manager.Name))
            {
                ModelState.AddModelError("ManagerId", "This Id not exists");
                return View();
            }
            ViewBag.Surname = surname;
            ViewBag.Book = book;
            db.Books.Add(book);
            db.SaveChanges();
            return View("NewBookRez", manager);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }

    }
}