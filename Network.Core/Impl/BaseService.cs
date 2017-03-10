
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
    public class BaseService<IRepository,TEntity, TKey> : IBaseService<TEntity, TKey> 
       where TEntity : BaseEntity
       where IRepository : IRepository<TEntity, TKey>
    {
        protected IRepository _IRepository;
        protected UnitOfWork _unitOfWork;
       
       
        public BaseService(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;               
          //  _IRepository = new Repository<TEntity, TKey>(_unitOfWork);
        }
        public BaseService()
        {
            _unitOfWork = new UnitOfWork();
        //    _IRepository = new Repository<TEntity, TKey>(_unitOfWork);
        }
        public bool Add(TEntity TEntity) => _IRepository.Insert(TEntity);
        public bool Delete(TKey id) => _IRepository.Delete(id);
        public IEnumerable<TEntity> GetAll() => _IRepository.GetAll();
        public TEntity GetById(TKey id) => _IRepository.GetById(id);
        public bool Update(TEntity TEntity) => _IRepository.Update(TEntity);
        public virtual bool UpdateWithChilds(TEntity entityToUpdate, HashSet<Type> childTypes)
        {
            return true;
        }

        public virtual IEnumerable<TEntity> GetAllToView() => _IRepository.GetList(x => x.IsDeleted == false).OrderBy(x => x.CreatedOn).AsEnumerable();

        public T getMapperDTO<T>(TEntity p)
        {
            return Mapper.Map<T>(p);
        }

        public TEntity getFromMapperDTO<T>(T dto)
        {
            return Mapper.Map<TEntity>(dto);
        }


    }
}
