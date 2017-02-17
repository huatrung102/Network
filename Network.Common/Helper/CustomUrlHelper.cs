using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Helper
{
    public class CustomUrlHelper
    {
        public static string CurrentAction(System.Web.Mvc.UrlHelper urlHelper)
        {
            var routeValueDictionary = urlHelper.RequestContext.RouteData.Values;
            // in case using virtual dirctory 
            var rootUrl = urlHelper.Content("~/");
            return string.Format("{1}/{2}", rootUrl, routeValueDictionary["controller"], routeValueDictionary["action"]);
        }
    }
}
