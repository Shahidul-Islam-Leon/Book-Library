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
    public class CustomerController : Controller
    {
        // GET: Customer
        UserRepository ur = new UserRepository();
        BookRepository br = new BookRepository();

        ImageRepository ir = new ImageRepository();


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
            using (UserRepository ur = new UserRepository())
            {
                var getUser = ur.Get(user.Id);
                user.UserType = getUser.UserType;


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


        [HttpPost]
        public ActionResult ChangePass(User user, string oPass, string nPass, string cPass)
        {

            var getUser = ur.Get(user.Id);


            if (getUser.Password == oPass)
            {

                if (nPass == cPass)
                {
                    //user.ConfirmPassword = cPass;
                    getUser.Password = nPass;
                    ur.Update(getUser);

                    return RedirectToAction("index", "Login");
                }
                else
                {
                    TempData["error"] = " password doesn't match";
                }
            }

            else
            {
                TempData["error"] = "incorrect old password";
            }

            return View();


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


        [HttpGet]
        public ActionResult ProfilePicture()
        {
            return View();
        }


        [HttpPost]
        public ActionResult ProfilePicture(Image image, HttpPostedFileBase postedImage)
        {

            if (ModelState.IsValid)
            {

                byte[] bytes;
                using (BinaryReader breader = new BinaryReader(postedImage.InputStream))
                {
                    bytes = breader.ReadBytes(postedImage.ContentLength);
                }


                // get imageFromDB by userID

                var getImageData = ir.Get(image.UserId);
                

                if (getImageData==null)// if imageFromDB is null the insert
                {
                    image.Name = Path.GetFileName(postedImage.FileName);
                    image.ImageData = bytes;


                    image.UserId = (int)Session["ID"];

                    ir.Insert(image);
                }
                else // else Update
                {

                    ir.Update(image);
                }

                return RedirectToAction("CProfile", "Customer", new { id = (int)Session["ID"] });
            }
            else
            {
                return View();
            }
        }

       



        }
}




