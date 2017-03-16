using Network.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Network.Core.Interfaces
{
    public interface IBaseService<TEntity,in TKey> where TEntity: BaseEntity
    {
        
        IEnumerable<TEntity> GetAllToView();
        IEnumerable<TEntity> GetAll();

        TEntity GetById(TKey id);

        bool Add(TEntity TEntity);

        bool Update(TEntity TEntity);
       // bool UpdateWithChilds(TEntity entityToUpdate, HashSet<Type> childTypes);
        bool Delete(TKey id);

        T getMapperDTO<T>(TEntity entity);
        TEntity getFromMapperDTO<T>(T dto);
    }
}
