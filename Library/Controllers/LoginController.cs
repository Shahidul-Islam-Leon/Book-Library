using Library.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        DBEntities context = new DBEntities();
        public ActionResult Index()
        {

            return View();

        }

        [HttpPost]
        public ActionResult Index(User user)
        {

            var checkedUser = context.Users.Where(x => x.Username.Equals(user.Username) & x.Password.Equals(user.Password)).FirstOrDefault();

            if (checkedUser != null)
            {
                Session["UserType"] = checkedUser.UserType;
                Session["Username"] = checkedUser.Username;
                Session["Id"] = checkedUser.Id;

                if ((string)Session["UserType"] == "Admin")
                {

                    return RedirectToAction("Index", "Admin");
                }

                else if ((string)Session["UserType"] == "Customer")
                {
                    return RedirectToAction("Index", "Customer");
                }

            }
            else
            {
                TempData["error"] = "incorrect username or password";
                return RedirectToAction("Index", "Login");
            }


            return View();
        }
    }
}