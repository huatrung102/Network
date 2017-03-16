using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Helper
{
    public static class MappingHelper
    {
        public static T Map<T>(this object source)
        {
            Mapper.CreateMap(source.GetType(), typeof(T));
            T des = (T)Mapper.Map(source, source.GetType(), typeof(T));
            return des;
        }

        public static IEnumerable<T> Map<T>(this IEnumerable<object> source)
        {
            Type sourceType = source.GetType().GetGenericArguments()[0];
            Mapper.CreateMap(sourceType, typeof(T));
            IEnumerable<T> des = (IEnumerable<T>)Mapper.Map(source, source.GetType(), typeof(IEnumerable<T>));
            return des;
        }
    }
}
