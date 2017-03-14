using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Common.Helper
{
    public static class GeoHelper
    {
        /// <summary>
        /// Create a GeoLocation point based on latitude and longitude
        /// </summary>
        /// <param name="latitude"></param>
        /// <param name="longitude"></param>
        /// <returns></returns>
        public static DbGeography CreatePoint(double latitude, double longitude)
        {
            var text = string.Format("Point({0} {1})", longitude, latitude).Replace(',','.');
            // 4326 is most common coordinate system used by GPS/Maps
            return DbGeography.PointFromText(text, 4326);
        }

        /// <summary>
        /// Create a GeoLocation point based on latitude and longitude
        /// </summary>
        /// <param name="latitudeLongitude">
        /// String should be two values either single comma or space delimited
        /// 45.710030,-121.516153
        /// 45.710030 -121.516153
        /// </param>
        /// <returns></returns>
        public static DbGeography CreatePoint(string latitudeLongitude)
        {
            var tokens = latitudeLongitude.Split(',', ' ');
            if (tokens.Length != 2)
                throw new ArgumentException("");
            var text = string.Format("POINT({0} {1})", tokens[1], tokens[0]);
            return DbGeography.PointFromText(text, 4326);
        }
    }
}
