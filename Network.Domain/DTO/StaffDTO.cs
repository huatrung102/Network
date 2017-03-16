using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class StaffDTO
    {
        public Guid StaffId { get; set; }

        public string StaffName { get; set; }

        public string StaffPhone { get; set; }

        public string StaffEmail { get; set; }
        public bool StaffIsHeadOffice { get; set; }
        public bool StaffExistHeadOffice { get; set; }
        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        //for report
        public DepartmentDTO Department { get; set; }
        public Guid LocationId { get; set; }
        public string LocationName { get; set; }

        
       
        public virtual Guid PositionId { get; set; }

      //  public virtual Position Position }
        public string PositionName { get; set; }
        //số lượng có của staff default = 1
        public int StaffCount
        {
            get; set;
        }
    }
}
