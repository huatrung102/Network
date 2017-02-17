using Network.Common.Helper;
using Network.Core.Impl;
using Network.Core.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using Network.Web.Test;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class HomeController : Controller
    {
        static string Url = "Home";
        public HomeController()
        {           
           
        }
        
        // GET: Home
        public ActionResult Index()
        {
            return View();
        }
        
    }
}