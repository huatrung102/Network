using Network.Core.Interfaces;
using Network.Data.Repository.Impl;
using Network.Data.Repository.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;

namespace Network.Core.Impl
{
    public class PositionService : BaseService<IPositionRepository, Position, Guid>, IPositionService
    {
        public PositionService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new PositionRepository(_unitOfWork);
        }
        public PositionService() : base() {
            _IRepository = new PositionRepository(_unitOfWork);
        }
    }
}
