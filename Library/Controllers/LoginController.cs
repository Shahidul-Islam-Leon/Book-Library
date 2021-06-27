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
        public ActionResult Index()
        {
            if (Session["UserType"] == null)
            {

                return View();
            }
            else
            {
                if ((string)Session["UserTpe"] == "Admin")
                {
                    return RedirectToAction("../Admin/index");
                }
                else if ((string)Session["UserTpe"] == "Customer")
                {
                    return RedirectToAction("../user/index");

                }
                else
                {
                    TempData["Error"] = "Restricted!";
                    Session.Clear();
                    Session.Abandon();
                    return Content("<a href=\"../login/Index/\"><p>Goto Homepage</p></a>");
                }

            }
        }

        [HttpPost]
        public ActionResult Index(User user)
        {
            LibraryDBEntities context = new LibraryDBEntities();
            var checkedUser = context.Users.Where(x => x.Username.Equals(user.Username) & x.Password.Equals(user.Password)).FirstOrDefault();

            if (checkedUser !=null)
            {
                Session["UserType"] = checkedUser.UserType;

                if ((string)Session["UserType"] == "Admin")
                {
                    return RedirectToAction("Index", "Admin");
                }

                else if ((string)Session["UserType"] == "Customer")
                {
                    return RedirectToAction("Index", "User");
                }
            }
            else
            {
                return View();
            }
            return View();
        }
    }
}