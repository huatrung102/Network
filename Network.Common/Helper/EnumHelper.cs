using Network.Common.DefineAttribute;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using UnconstrainedMelody;

namespace Network.Common.Helper
{
    public static class EnumHelper 
    {
        private static string GetDescription(Enum value)
        {
            if (value == null)
            {
                throw new ArgumentNullException("value");
            }

            string description = value.ToString();
            FieldInfo fieldInfo = value.GetType().GetField(description);
            DescriptionAttribute[] attributes =
               (DescriptionAttribute[])
             fieldInfo.GetCustomAttributes(typeof(DescriptionAttribute), false);

            if (attributes != null && attributes.Length > 0)
            {
                description = attributes[0].Description;
            }
            return description;
        }

        /// <span class="code-SummaryComment"><summary></span>
        /// Converts the <span class="code-SummaryComment"><see cref="Enum" /> type to an <see cref="IList" /> </span>
        /// compatible object.
        /// <span class="code-SummaryComment"></summary></span>
        /// <span class="code-SummaryComment"><param name="type">The <see cref="Enum"/> type.</param></span>
        /// <span class="code-SummaryComment"><returns>An <see cref="IList"/> containing the enumerated</span>
        /// type value and description.<span class="code-SummaryComment"></returns></span>
        public static IList ToList(Type type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(type);

            foreach (Enum value in enumValues)
            {
                list.Add(new KeyValuePair<Enum, string>(value, GetDescription(value)));
            }

            return list;
        }
        //use for get enum list and Localized purpose
        public static string ToEnumerable<T>() where T : struct, IConvertible
        {

            ArrayList list = new ArrayList();
            Array enumValues = Enum.GetValues(typeof(T));

            foreach (T value in enumValues)
            {
                list.Add(new KeyValuePair<T, string>(value, GetDescription(value as Enum)));
            }           
            var values = from KeyValuePair<T, string> e in list
                         select String.Format(@"{{""Value"": {0:d}, ""Text"": ""{1}""}}", (e.Key as Enum), e.Value);
           
            //http://stackoverflow.com/questions/15933632/passing-array-to-function-that-takes-either-params-object-or-ienumerablet
            return "[" + String.Join(",", (object[])values.ToArray()) + "]";
        }
        /*




              public static string ToNameText(this Enum en)
              {

                  Type type = en.GetType();

                  MemberInfo[] memInfo = type.GetMember(en.ToString());

                  if (memInfo != null && memInfo.Length > 0)
                  {

                      object[] attrs = memInfo[0].GetCustomAttributes(
                                                    typeof(DisplayTextEnum),

                                                    false);

                      if (attrs != null && attrs.Length > 0)

                          return ((DisplayTextEnum)attrs[0]).Text;

                  }

                  return en.ToString();

              }
              */
    }
}
