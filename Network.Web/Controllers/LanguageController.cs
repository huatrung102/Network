using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading;
using System.Web;
using System.Web.Mvc;

namespace Network.Web.Controllers
{
    public class LanguageController : Controller
    {
        // GET: Language
       
        public void Change(string data)
        {
            if(data != null)
            {
                Thread.CurrentThread.CurrentCulture = CultureInfo.CreateSpecificCulture(data);
                Thread.CurrentThread.CurrentUICulture = new CultureInfo(data);
            }
            HttpCookie cookie = new HttpCookie("_lang");
            cookie.Expires = DateTime.Now.AddYears(10);
            cookie.Value = data;
            Response.Cookies.Add(cookie);
            if (Request.UrlReferrer != null)
                Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            else
                Response.Redirect("/");
        }
    }
}