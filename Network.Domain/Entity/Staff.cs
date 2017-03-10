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
    //danh sách, số lượng cán bộ tại địa điểm
    public class Staff : BaseEntity
    {

        [Key]
        public Guid StaffId { get; set; }
        [MaxLength(50)]
        public string StaffName { get; set; }
        [MaxLength(50)]
        public string StaffPhone { get; set; }
        [MaxLength(50)]
        [Index("StaffEmailIndex", IsUnique = true)]
        public string StaffEmail { get; set; }
        public bool StaffIsHeadOffice { get; set; }

        public virtual Guid DepartmentId { get; set; }

        public virtual Department Department { get; set; }

        public virtual Guid PositionId { get; set; }        
        public virtual Position Position { get; set; }
        //số lượng có của staff default = 1
        public int StaffCount { get; set; }
        //loại 
     //   public EType.StaffTypeEnum StaffType { get; set; }
       

    }
}
