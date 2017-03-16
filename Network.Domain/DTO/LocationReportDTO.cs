using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Domain.DTO
{
    public class LocationReportDTO
    {
        public LocationReportDTO()
        {
            this.Departments = new HashSet<DepartmentDTO>();
            this.Documents = new HashSet<DocumentDTO>();
            this.Contracts = new HashSet<ContractDTO>();
            this.Staffs = new HashSet<StaffDTO>();
        }
        public string LocationName { get; set; }
        public string LocationCode { get; set; }
        public Guid StaffHeadOfficeId { get; set; }
        public StaffDTO StaffHeadOffice
        {
            get
            {
                return Staffs.Where(x => x.StaffIsHeadOffice).SingleOrDefault();
            }            
        }

        public DepartmentDTO StaffHeadOfficeDepartment
        {
            get
            {
                return StaffHeadOffice.Department;
            }
        }

        public Guid DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        
        public int StaffTotalCount
        {
            get
            {
                var count = 0;
                foreach(DepartmentDTO dto in Departments)
                {
                    count += dto.StaffCount;
                }
                return count;
            }
            
        }

        public virtual Contract Contract { get; set; }
        //số tiên thuê hàng tháng --> có thể sẽ thay đổi value by Cost (chưa làm đến hiện tại)
        public float ContractBalance { get; set; }
        //tiền cọc
        public short ContractDeposit { get; set; }

        public virtual ICollection<StaffDTO> Staffs { get; set; }
        //danh sách phòng ban thuộc chi nhánh --> danh sách Staffs thuộc phòng ban
        public virtual ICollection<DepartmentDTO> Departments { get; set; }

        public virtual ICollection<DocumentDTO> Documents { get; set; }
        public virtual ICollection<ContractDTO> Contracts { get; set; }

    }
}
