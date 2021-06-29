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
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult AddAdmin()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddAdmin(User user)
        {
            
            user.UserType = "Admin";
            ur.Insert(user);
            
            return View();
        }
    }
}