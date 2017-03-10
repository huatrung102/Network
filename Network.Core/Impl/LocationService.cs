using AutoMapper;
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
    public class LocationService : BaseService<ILocationRepository, Location, Guid>, ILocationService
    {
        public LocationService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new LocationRepository(_unitOfWork);
        }
        public LocationService() : base() {
            _IRepository = new LocationRepository(_unitOfWork);
        }

    }
}
