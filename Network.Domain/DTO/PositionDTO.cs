using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class PositionDTO 
    {
        public Guid PositionId { get; set; }
       
        public string PositionName { get; set; }
        public bool PositionIsLeader { get; set; }
        //để dành sau này design giao diện org chart 
        public int? PositionCode { get; set; }
        //để dành sau này design giao diện org chart
        public int? PositionParentCode { get; set; }
    }
}
