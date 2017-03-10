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
    public class ProvinceRepository : Repository<Province, short>, IProvinceRepository
    {
        public ProvinceRepository(UnitOfWork _context) : base(_context)
        {
        }
    }
}
