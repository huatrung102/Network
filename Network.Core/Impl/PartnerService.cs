using AutoMapper;
using Network.Core.Interfaces;
using Network.Data.Repository.Impl;
using Network.Data.Repository.Interfaces;
using Network.Data.UoW;
using Network.Domain.Entity;
using System;

namespace Network.Core.Impl
{
    public class PartnerService : BaseService<IPartnerRepository, Partner, Guid>, IPartnerService
    {
        public PartnerService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new PartnerRepository(_unitOfWork);
        }
        public PartnerService() : base() {
            _IRepository = new PartnerRepository(_unitOfWork);
        }

        
       
    }
}
