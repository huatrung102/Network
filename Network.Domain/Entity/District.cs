using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class District : BaseEntity
    {
        [Key]
        public short DistrictId { get; set; }

        [MaxLength(50)]
        public string DistrictName { get; set; }
        [ForeignKey("Province")]
        public short ProvinceId { get; set; }
        
        public Province Province { get; set; }
    }
}
