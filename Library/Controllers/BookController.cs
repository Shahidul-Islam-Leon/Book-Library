using Library.Models;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{

    public class BookController : Controller
    {

        BookRepository br = new BookRepository();
        // GET: Book
        public ActionResult Index()

        {
            if ((string)Session["UserType"] == "Admin")
            {
                var r = br.GetALLData();
                return View(r);
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        [HttpGet]
        public ActionResult Edit(int id)

        {

            if ((string)Session["UserType"] == "Admin")
            {

                return View(br.Get(id));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        [HttpPost]
        public ActionResult Edit(Book book)

        {

            br.Update(book);
            return RedirectToAction("Index", "Book");


        }


        [HttpGet]
        public ActionResult Delete(int id)

        {

            if ((string)Session["UserType"] == "Admin")
            {

                return View(br.Get(id));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)

        {

            br.Delete(id);
            return RedirectToAction("Index", "Book");


        }


        [HttpGet]
        public ActionResult AddBook()

        {

            if ((string)Session["UserType"] == "Admin")
            {
                GenreRepository gr = new GenreRepository();
                ViewData["Genres"] = gr.GetALLData();
                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpPost]
        public ActionResult AddBook(Book book, HttpPostedFileBase postedFile)
        {

            if (ModelState.IsValid)
            {
                BookRepository br = new BookRepository();

                byte[] bytes;
                using (BinaryReader breader = new BinaryReader(postedFile.InputStream))
                {
                    bytes = breader.ReadBytes(postedFile.ContentLength);
                }

                book.PdfName = Path.GetFileName(postedFile.FileName);
                book.BookData = bytes;

                br.Insert(book);
                return RedirectToAction("Index", "Book");
            }
            else
            {
                return View();
            }
        }

    }
}