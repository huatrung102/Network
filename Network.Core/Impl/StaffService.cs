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
    public class StaffService : BaseService<IStaffRepository, Staff, Guid>, IStaffService
    {
        public StaffService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new StaffRepository(_unitOfWork);
        }
        public StaffService() : base() {
            _IRepository = new StaffRepository(_unitOfWork);
        }


    }
}
