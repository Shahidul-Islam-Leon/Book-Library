using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class HomeController : Controller
    {
        
        public ActionResult Index()
        {
            String path = Server.MapPath("~/Images/");
            String[] imagesfiles = Directory.GetFiles(path);
            ViewBag.Images = imagesfiles;

            return View();
        }      

    }
}