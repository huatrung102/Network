using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using Network.Data.UoW;
using Network.Domain.Entity;

namespace Network.Data.Repository.Interfaces
{
    public interface IRepository<TEntity, in TKey> : IUnitOfWork where TEntity : BaseEntity
    {
        IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null,
                                 Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null,
                                 string includeProperties = "");

        TEntity SearchByTerm(Expression<Func<TEntity, bool>> filter, string includeProperties); 
        
        TEntity GetById(TKey id);

        bool Insert(TEntity entity);

        bool Delete(TKey id);

        bool Update(TEntity entityToUpdate);

        bool UpdateWithChilds(TEntity entityToUpdate, HashSet<Type> childTypes);
        bool UpdateWithChilds<TEntityState>(TEntityState entityToUpdate, HashSet<Type> childTypes)
        where TEntityState : BaseEntity, IObjectWithState;
        IEnumerable<TEntity> GetAll();
    }
}
