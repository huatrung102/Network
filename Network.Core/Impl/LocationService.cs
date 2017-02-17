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
    public class LocationService : BaseService<Location, Guid>, ILocationService
    {
        public LocationService(UnitOfWork UnitOfWork) : base(UnitOfWork) { }
        public LocationService() : base() { }
    }
}
