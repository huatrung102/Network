using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.Entity
{
   public class Position : BaseEntity
    {
        [Key]
        public Guid PositionId { get; set; }
        [MaxLength(50)]
        public string PositionName { get; set; }
        public bool PositionIsLeader { get; set; }
        //để dành sau này design giao diện org chart 
        public int? PositionCode { get; set; }
        //để dành sau này design giao diện org chart
        public int? PositionParentCode { get; set; }

        

        public virtual ICollection<Staff> Staffs { get; set; }

    }
}
