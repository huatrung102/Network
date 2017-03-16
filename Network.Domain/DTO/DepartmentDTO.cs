using Network.Domain.Entity;
using Network.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class DepartmentDTO 
    {
        public DepartmentDTO()
        {
            this.Staffs = new HashSet<Staff>();
        }
        public Guid DepartmentId { get; set; }
       
        public string DepartmentName { get; set; }

      //  public virtual Guid LocationId { get; set; }
        public EType.DepartmentGroupEnum DepartmentGroup { get; set; }
        public string DepartmentGroupName { get; set; }
        public int StaffCount
        {
            get
            {
                var count = 0;
                foreach(Staff s in Staffs)
                {
                    count += s.StaffCount;
                }
                return count;
            }
        }
        //   public string LocationName { get; set; }
        public virtual ICollection<Staff> Staffs { get; set; }
    }
}
