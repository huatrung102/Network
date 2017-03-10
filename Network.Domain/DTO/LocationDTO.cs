using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data.Entity.Spatial;
using System.Web.Script.Serialization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class LocationDTO
    {
       
        public string LocationName { get; set; }
        
        public Guid? LocationId { get; set; }        
        public string LocationCode { get; set; }
        
        public string LocationParentCode { get; set; }
        
        public string LocationAddress { get; set; }
        
        public string LocationPhone { get; set; }
       
        public string LocationFax { get; set; }

        public EType.AreaTypeEnum LocationArea { get; set; }

        public float? LocationAreaM2 { get; set; }
        [ScriptIgnore]
        public DbGeography LocationPoint { get; set; }
        public double LocationLatitude { get; set; }
        public double LocationLongitude { get; set; }
        
        /*
        private double _LocationLatitude  ;
        public double? LocationLatitude {
            get {
                if (LocationPoint == null) return 10.7821116F;
                else return _LocationLatitude;
            }
            set {
                _LocationLatitude = value == null ? default(double) : (double)value;
            }
        }
        private double _LocationLongitude;
        public double? LocationLongitude {
            get
            {
                if (LocationPoint == null) return 106.7037574F;
                else return _LocationLongitude;
            }
            set
            {
                _LocationLongitude = value == null ? default(double) : (double)value;
            }
        }
       */
        public string LocationDescription { get; set; }
        //hình hiện trạng hiện tại của địa điểm
        public virtual ICollection<LocationFileAttachment> LocationFileAttachments { get; set; }
    }
}
