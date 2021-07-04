using Library.Models;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin

        UserRepository ur = new UserRepository();
        DBEntities context = new DBEntities();

        [HttpGet]
        public ActionResult Index()
        {
            if ((string)Session["Usertype"] == "Admin")
            {
                return View();
            }


            else
            {
                return RedirectToAction("index", "Login");

            }
        }


        [HttpGet]
        public ActionResult Admins()
        {
            if ((string)Session["Usertype"] == "Admin")
            {



                return View(ur.GetAllAdmin("Admin"));
            }


            else
            {
                return RedirectToAction("index", "Login");

            }
        }





        [HttpGet]
        public ActionResult AddAdmin()
        {

            if ((string)Session["Usertype"] == "Admin")
            {
                return View();
            }


            else
            {
                return RedirectToAction("index", "Login");

            }
        }

        [HttpPost]
        public ActionResult AddAdmin(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserType = "Admin";
                ur.Insert(user);

                return RedirectToAction("Admins", "Admin");

            }
            else
            {
                return View();
            }

        }


        [HttpGet]
        public ActionResult Delete(int id)
        {
            if ((string)Session["Usertype"] == "Admin")
            {
                return View(ur.Get(id));
            }


            else
            {
                return RedirectToAction("index", "Login");

            }

        }

        [HttpPost, ActionName("Delete")]
        public ActionResult ConfirmDelete(int id)
        {
            ur.Delete(id);
            return RedirectToAction("Admins", "Admin");
        }



        [HttpGet]
        public ActionResult AdminProfile(int id)
        {
            if ((string)Session["Usertype"] == "Admin")
            {
               // var users = ur.GetALLData();
                // return View(users.Find(x => x.Id == 2));


                return View(ur.Get(id));


            }


            else
            {
                return RedirectToAction("index", "Login");

            }




        }

        


        [HttpPost]
        public ActionResult AdminProfile(User user)
        {
            using (UserRepository userRepo = new UserRepository())
            {
                var u = userRepo.Get(user.Id);
                user.UserType = u.UserType;
                user.ConfirmPassword = user.Password;

            }          

            ur.Update(user);
            return RedirectToAction("Index", "Admin");

        }
    }
}