using Network.Common.Extensions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
namespace Network.Common.Helper
{
    public static class  MvcHelper
    {
        public static MvcHtmlString ModelToJSon(this HtmlHelper html, object model)
        {
            if (model == null)
                return new MvcHtmlString("'null'");

           // var json = JsonConvert.SerializeObject(model);
            var json = JsonConvert.SerializeObject(model, Formatting.Indented,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            });
            
            json = HttpUtility.JavaScriptStringEncode(json, true);

            return new MvcHtmlString(json);
        }
        public static MvcHtmlString EnumToJson<T>(this HtmlHelper helper) where T : struct, IConvertible
        {

            var values = from T e in Enum.GetValues(typeof(T))
                         select String.Format(@"{{""Value"": {0:d}, ""Text"": ""{1}""}}",
                       //  e, EnumHelper.ToNameText(e.ToString().FromString()));
                       e, e.ToString());
            return MvcHtmlString.Create("[" + String.Join(",", values.ToArray()) + "]");

        }

        public static string getResponse<T>(int responseCode, T data,JsonError error = null)
        {
            JsonResponse<T> response = new JsonResponse<T>(responseCode, error, data);
            return SerializeObject(response);
        }
        public static string getResponse(int responseCode, JsonError error = null)
        {
            JsonResponse<string> response = new JsonResponse<string>(responseCode, error, null);
            return SerializeObject(response);
        }

        public static T DeserializeObject<T>(this string str)
        {
            if (str == null)
                str = string.Empty;
            var json = JsonConvert.DeserializeObject<T>(str,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            });
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static T DeserializeObject<T>(this string str, ReferenceLoopHandling loop)
        {
            if (str == null)
                str = string.Empty;
            var json = JsonConvert.DeserializeObject<T>(str,
            new JsonSerializerSettings
            {
                ReferenceLoopHandling = loop,
                PreserveReferencesHandling = PreserveReferencesHandling.None
            });
            return JsonConvert.DeserializeObject<T>(str);
        }
        public static string SerializeObject(this object obj)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    MaxDepth = 2,
                    ReferenceLoopHandling = ReferenceLoopHandling.Serialize,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                });
         //   json = HttpUtility.JavaScriptStringEncode(json, true);
            return json;
        }
        public static string SerializeObject(this object obj, ReferenceLoopHandling loop)
        {
            var json = JsonConvert.SerializeObject(obj, Formatting.Indented,
                new JsonSerializerSettings
                {
                    MaxDepth = 2,
                    ReferenceLoopHandling = loop,
                    PreserveReferencesHandling = PreserveReferencesHandling.None
                });
          //  json = HttpUtility.JavaScriptStringEncode(json, true);
            return json;
        }
        public static string RenderViewToString(ControllerContext  context, string viewName, object model)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = context.RouteData.GetRequiredString("action");

            var viewData = new ViewDataDictionary(model);

            using (var sw = new StringWriter())
            {
                var viewResult = ViewEngines.Engines.FindPartialView(context, viewName);
                var viewContext = new ViewContext(context, viewResult.View, viewData, new TempDataDictionary(), sw);
                viewResult.View.Render(viewContext, sw);

                return sw.GetStringBuilder().ToString();
            }
        }
    }
}
