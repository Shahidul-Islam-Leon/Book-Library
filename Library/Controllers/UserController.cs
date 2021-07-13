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
        public ActionResult Registration(User user,string ConfirmPassword)
        {
            if (ModelState.IsValid)
            {

                if (user.Password==ConfirmPassword)
                {
                    user.UserType = "Customer";
                    ur.Insert(user);

                    return RedirectToAction("../home/index");
                }
                else
                {
                    TempData["error"] = "Confirm password doesn't match";
                }
                
            }
           
                return View();
            
        }



    }
}