using Network.Common.DefineAttribute;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Helper
{
    public static class EnumHelper
    {
        public static T ToEnum<T>(this string value) where T: IConvertible
        {
            if (!typeof(T).IsEnum)
            {
                throw new ArgumentException("Generic Type 'T' must be an Enum");
            }
            if (!string.IsNullOrEmpty(value))
            {
                if (Enum.GetNames(typeof(T)).Any(
                      e => e.Trim().ToUpperInvariant() == value.Trim().ToUpperInvariant()))
                {
                    return (T)Enum.Parse(typeof(T), value, true);
                }
            }
            return default(T);
        }

        public static Enum FromString(this string value)
        {
            return ToEnum<Enum>(value); 
        }


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
    }
}
