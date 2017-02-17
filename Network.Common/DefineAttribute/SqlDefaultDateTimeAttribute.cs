using System;

namespace Network.Common.DefineAttribute
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SqlDefaultDateTimeAttribute : Attribute
    {
        public string DefaultValue { get; set; }
    }
}
