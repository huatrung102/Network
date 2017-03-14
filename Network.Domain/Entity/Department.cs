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
    public class Department : BaseEntity
    {
        public Department()
        {
            this.Staffs = new HashSet<Staff>();
        }

        [Key]
        public Guid DepartmentId { get; set; }

        [MaxLength(50)]
        public string DepartmentName { get; set; }

        public EType.DepartmentGroupEnum DepartmentGroup { get; set; }


        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
