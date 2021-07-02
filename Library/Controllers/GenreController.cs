using Library.Models;
using Library.Models.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class GenreController : Controller
    {
        GenreRepository gr = new GenreRepository();
        // GET: Genre
        [HttpGet]
        public ActionResult Index()
        {
            if ((string)Session["UserType"]=="Admin")
            {
                
                return View(gr.GetALLData());
            }
            else
            {
                return RedirectToAction("Index","Login");
            }
            
        }



        [HttpGet]


        public ActionResult AddGenre()
        {

            if ((string)Session["UserType"] == "Admin")
            {

                return View();
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }

        }

        [HttpPost]
        public ActionResult AddGenre(Genre genre)
        {
            if (ModelState.IsValid)
            {
                gr.Insert(genre);
                return RedirectToAction("Genre", "Admin");
            }
            else
            {
                return View();
            }
           

        }

    }
}