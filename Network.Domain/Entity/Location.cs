using Network.Common.Extensions;
using Network.Domain.Enum;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.Spatial;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Location : BaseEntity
    {
        public Location()
        {
            
            this.LocationFileAttachments = new HashSet<LocationFileAttachment>();
            this.Contracts = new HashSet<Contract>();
         
            this.Staffs = new HashSet<Staff>();

        }
        [MaxLength(50)]
        public string LocationName { get; set; }
        [Key]
        public Guid LocationId { get; set; }
        [MaxLength(3)]
        [Index("LocationCodeIndex",IsUnique =true)]
        public string LocationCode { get; set; }
        [MaxLength(3)]
        public string LocationParentCode { get; set; }
        [MaxLength(300)]
        public string LocationAddress { get; set; }
        [MaxLength(50)]
        public string LocationPhone { get; set; }
        [MaxLength(50)]
        public string LocationFax { get; set; }
        //khu vực
        public EType.AreaTypeEnum LocationArea { get; set; }

      //  public EType.LocationTypeEnum LocationType { get; set; }
        //diện tích
        public float? LocationAreaM2 { get; set; }
        //mặt bằng phía trước
        public float? LocationFrontSpace { get; set; }
        //vị trí
        [JsonConverter(typeof(GeographyConverter))]
        public DbGeography LocationPoint { get; set; }


        [MaxLength(300)]
        public string LocationDescription { get; set; }
        //hình hiện trạng hiện tại của địa điểm
        public virtual ICollection<LocationFileAttachment> LocationFileAttachments { get; set; }

        public virtual ICollection<Contract> Contracts { get; set; }

       
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
