﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Library.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}