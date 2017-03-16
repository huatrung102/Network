using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
    public class Province : BaseEntity
    {
        [Key]
        public short ProvinceId { get; set; }

        [MaxLength(50)]
        public string ProvinceName { get; set; }

        public short ProvinceOrder { get; set; }

        public ICollection<District> Districts { get; set; }
    }
}
