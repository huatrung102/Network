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
       public LocationDTO()
        {
            this.LocationId = Guid.NewGuid();
            this.LocationFileAttachments = new HashSet<LocationFileAttachment>();
            //use for event click choose location to change on map
            this.selected = false;
        }
        public string LocationName { get; set; }
        
        public Guid LocationId { get; set; }        
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

        public float? LocationFrontSpace { get; set; }

        public string LocationDescription { get; set; }

        public bool selected { get; set; }
        //hình hiện trạng hiện tại của địa điểm
        public virtual ICollection<LocationFileAttachment> LocationFileAttachments { get; set; }
    }
}
