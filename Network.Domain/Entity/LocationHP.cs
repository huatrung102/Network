using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class LocationHP : BaseEntity
    {
        //địa điểm dự án - tên dự án
        [MaxLength(50)]
        public string LocationHPName { get; set; }
        [Key]
        public Guid LocationHPId { get; set; }
        [MaxLength(300)]
        public string LocationHPAddress { get; set; }
        //quận huyện - use to search
        public District District { get; set; }
        //tỉnh thành phố - use to search
        public virtual Province Province { get; set; }
               

       
    }
}
