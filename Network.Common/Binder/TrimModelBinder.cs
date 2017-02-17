using Network.Common.DefineAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Web.Mvc;

namespace Network.Common.Binder
{
   // http://stackoverflow.com/questions/1718501/asp-net-mvc-best-way-to-trim-strings-after-data-entry-should-i-create-a-custo
   //solution about trim value string 
    public class TrimModelBinder : DefaultModelBinder
    {
        protected override void SetProperty(ControllerContext controllerContext,
      ModelBindingContext bindingContext,
      System.ComponentModel.PropertyDescriptor propertyDescriptor, object value)
        {
            if (propertyDescriptor.PropertyType == typeof(string) 
                && !propertyDescriptor.Attributes.Cast<object>().Any(a => a.GetType() == typeof(StringTrimAttribute)))
            {
                var stringValue = (string)value;
                value = !string.IsNullOrWhiteSpace(stringValue) ? value = stringValue.Trim() : "";               
            }

            base.SetProperty(controllerContext, bindingContext,
                                propertyDescriptor, value);
        }
    }
}
