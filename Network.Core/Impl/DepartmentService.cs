using Network.Core.Interfaces;
using Network.Data.Repository.Impl;
using Network.Data.Repository.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Impl
{
    public class DepartmentService : BaseService<IDepartmentRepository, Department, Guid>, IDepartmentService
    {
        public DepartmentService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new DepartmentRepository(_unitOfWork);
        }
        public DepartmentService() : base() {
            _IRepository = new DepartmentRepository(_unitOfWork);
        }

    }
}
