using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Location : BaseEntity
    {
        public Location()
        {
            this.LocationFileAttachments = new HashSet<FileAttachment>();
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
        
        public EType.AreaType LocationArea { get; set; }

        public float? LocationAreaM2 { get; set; }

        public float? CoordinateX { get; set; }
        public float? CoordinateY { get; set; }

      
        [MaxLength(300)]
        public string LocationDescription { get; set; }
        //hình hiện trạng hiện tại của địa điểm
        public virtual ICollection<FileAttachment> LocationFileAttachments { get; set; }

    }
}
