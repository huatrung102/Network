using Network.Data.Repository.Impl;
using Network.Data.Repository.Interfaces;
using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Network.Data.Context;
using Network.Data.UoW;
using System.Data.Entity;
using Network.Common.Extensions;

namespace Network.Data.Repository.Impl
{
    public class PartnerRepository : Repository<Partner,Guid>, IPartnerRepository
    {
        public PartnerRepository(UnitOfWork _context) : base(_context)
        {
        }
                
    }
}
