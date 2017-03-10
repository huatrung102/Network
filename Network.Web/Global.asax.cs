using Network.Core.Mapping;
using Network.UI.App_Start;
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
    }
}
