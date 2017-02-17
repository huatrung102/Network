using Network.Data.Repository.Impl;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network.Data.Context;
using Network.Data.Repository.Interfaces;
using Network.Data.UoW;

namespace Network.Data.Repository.Impl
{
    public class IntegrityPlanRepository : Repository<IntegrityPlan, Guid>, IIntegrityPlanRepository
    {
        public IntegrityPlanRepository(UnitOfWork _context) : base(_context)
        {
        }
    }
}
