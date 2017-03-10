using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class DepartmentDTO 
    {
        public Guid DepartmentId { get; set; }
       
        public string DepartmentName { get; set; }

        public virtual Guid LocationId { get; set; }
       
        public string LocationName { get; set; }
    }
}
