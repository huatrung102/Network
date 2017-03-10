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
    public class ContractService : BaseService<IContractRepository,Contract, Guid>, IContractService
    {
        public ContractService(UnitOfWork UnitOfWork) : base(UnitOfWork) {
            _IRepository = new ContractRepository(_unitOfWork);
        }
        public ContractService() : base() {
            _IRepository = new ContractRepository(_unitOfWork);
        }

    }
}
