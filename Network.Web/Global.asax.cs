using Network.Core.Mapping;
using Network.UI.App_Start;
using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Network.Web
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);
            //using for trim model sourceKey TrimModelBinder
            // ModelBinders.Binders.Add(typeof(decimal), new TrimModelBinder());

            ModelMapping.Register();
        }
        protected void Application_AcquireRequestState(object sender, EventArgs e)
        {

            HttpCookie cookie = HttpContext.Current.Request.Cookies["_lang"];
            string language = cookie != null && cookie.Value != null ? cookie.Value : "en";
            System.Threading.Thread.CurrentThread.CurrentCulture =
                new System.Globalization.CultureInfo(language);
            System.Threading.Thread.CurrentThread.CurrentUICulture =
                new System.Globalization.CultureInfo(language);
        }
    }
}
