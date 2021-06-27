using Library.Models;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        UserRepository ur = new UserRepository();
        public ActionResult Index()
        {
            return View();
        }
        

        [HttpGet]
        public ActionResult Registration()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Registration(User user)
        {
            if (ModelState.IsValid)
            {
                user.UserType = "Customer";
                ur.Insert(user);

                return RedirectToAction("../home/index");
            }
            else
            {
                return View();
            }
        }
    }
}