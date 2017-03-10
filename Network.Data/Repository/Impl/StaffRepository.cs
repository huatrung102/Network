using Network.Data.Repository.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Data.Repository.Impl
{
    public class StaffRepository : Repository<Staff, Guid>, IStaffRepository
    {
        public StaffRepository(UnitOfWork _context) : base(_context)
        {
        }
    }
}
