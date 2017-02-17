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
        //   IEnumerable<TEntity> SearchListByTerm(string term);

        //   TEntity SearchByTerm(string term);

        //   IEnumerable<TEntity> SearchListByTermToView(string searchTerm, int pageSize, int pageNum);
        IEnumerable<TEntity> GetAllToView();
        IEnumerable<TEntity> GetAll();

        TEntity GetById(TKey id);

        bool Add(TEntity TEntity);

        bool Update(TEntity TEntity);

        bool Delete(TKey id);
    }
}
