using Library.Models;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class CustomerController : Controller
    {
        // GET: Customer
        UserRepository ur = new UserRepository();
        BookRepository br = new BookRepository();


        [HttpGet]
        public ActionResult Index()
        {

            if ((string)Session["Usertype"] == "Customer")
            {
                BookRepository br = new BookRepository();
                return View(br.GetALLData());
            }

            else
            {
                return RedirectToAction("index", "Login");

            }

        }


        [HttpGet]
        public ActionResult CustomerProfile(int id)
        {
            if ((string)Session["Usertype"] == "Customer")
            {



                return View(ur.Get(id));


            }


            else
            {
                return RedirectToAction("index", "Login");

            }

        }


        [HttpPost]
        public ActionResult CustomerProfile(User user)
        {
            using (UserRepository userRepo = new UserRepository())
            {
                var u = userRepo.Get(user.Id);
                user.UserType = u.UserType;
                user.ConfirmPassword = user.Password;

            }

            ur.Update(user);
            return RedirectToAction("Index", "Customer");

        }



        [HttpGet]
        public ActionResult CProfile(int id)
        {
            if ((string)Session["Usertype"] == "Customer")
            {



                return View(ur.Get(id));


            }


            else
            {
                return RedirectToAction("index", "Login");

            }

        }

        [HttpGet]
        public ActionResult ChangePass()
        {
            if ((string)Session["Usertype"] == "Customer")
            {

                return View();
            }

            else
            {
                return RedirectToAction("index", "Login");

            }

        }



        [HttpGet]
        public ActionResult Allbook()

        {
            if ((string)Session["UserType"] == "Customer")
            {

                return View(br.GetALLData());
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }


        [HttpGet]
        public ActionResult BookDetails(int id)

        {


            if ((string)Session["UserType"] == "Customer")
            {
                return View(br.Get(id));
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpGet]
        public FileResult BookDownload(int id)
        {
            DBEntities context = new DBEntities();

            var FileById = (from item in context.Books
                            where item.Id.Equals(id)
                            select new { item.PdfName, item.BookData }).ToList().FirstOrDefault();
            return File(FileById.BookData, "application/pdf", FileById.PdfName);

        }

    }

}

