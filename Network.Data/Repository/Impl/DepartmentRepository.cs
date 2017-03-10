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
    public class DepartmentRepository: Repository<Department, Guid>, IDepartmentRepository
    {
        public DepartmentRepository(UnitOfWork _context) : base(_context)
        {
    }
}
}
