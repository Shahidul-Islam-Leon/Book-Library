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
    }
}
