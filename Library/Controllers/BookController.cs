using Library.Models;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddBook()
        {
            return View();
        }
        
        public ActionResult AddBook(Book book)
        {

            if (ModelState.IsValid)
            {


                BookRepository br = new BookRepository();
                br.Insert(book);
                return Content("added");
            }
            else
            {
                return View();
            }
        }

    }
}