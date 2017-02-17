using Network.Core.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Impl
{
    public class CostService : BaseService<Cost, Guid>, ICostService
    {
        public CostService(UnitOfWork UnitOfWork) : base(UnitOfWork) { }
        public CostService() : base() { }
    }
}
