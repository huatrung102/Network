using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Network.Data.Repository.Interfaces;
using Network.Data.Context;
using Network.Common.Extensions;
using Network.Data.UoW;
using Network.Domain.Entity;

namespace Network.Data.Repository.Impl
{
    public class Repository<TEntity,TKey> : IRepository<TEntity,TKey> where TEntity : BaseEntity
    {
        
        internal DbSet<TEntity> dbSet;
        private IUnitOfWork UnitOfWork { get; set; }
        internal NetworkContext context;
        public Repository(UnitOfWork _UnitOfWork)
        {
            context = _UnitOfWork.dbContext;
            dbSet = context.Set<TEntity>();
        }

        public IEnumerable<TEntity> GetList(Expression<Func<TEntity, bool>> filter = null, 
                                        Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>> orderBy = null, 
                                        string includeProperties = "")
        {
            IQueryable<TEntity> query = dbSet;
               
            foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query.Include(prop);
            }
          var t=  query.Where(filter);
            //conditional return or ordered results
            return orderBy != null ? orderBy(t).ToList() : t.ToList();
        }

        public TEntity SearchByTerm(Expression<Func<TEntity, bool>> filter, string includeProperties)
        {
            IQueryable<TEntity> query = dbSet;

            
            foreach (var prop in includeProperties.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries))
            {
                query.Include(prop);
            }
          var t=  query.Where(filter);

            return t.FirstOrDefault();

        }

        public TEntity GetById(TKey id)
        {
            return dbSet.Find(id);
        }

        public bool Insert(TEntity entity)
        {
            try
            {
                dbSet.Add(entity);
                Commit();
                return true;
            }
            catch (Exception)
            {
               
            }
            return false;
            
        }

        public bool Delete(TKey id)
        {
            try
            {
                TEntity entityToDelete = dbSet.Find(id);
                Delete(entityToDelete);
                return true;
            }
            catch (Exception)
            {

               
            }
            return false;
        }

        public bool Delete(TEntity entityToDelete)
        {
            try
            {
                if (context.Entry(entityToDelete).State == EntityState.Detached)
                {
                    dbSet.Attach(entityToDelete);
                }

                dbSet.Remove(entityToDelete);
                Commit();
                return true;
            }
            catch (Exception)
            {

            }
            return false;

        }

        public bool Update(TEntity entityToUpdate)
        {
            try
            {
                context.Entry(entityToUpdate).State = EntityState.Modified;
                Commit();
                return true;
            }
            catch (Exception)
            {

            }
            return false;
        }

        public void Commit()
        {
            context.SaveChanges();
        }

        private bool _disposed;

        public void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            _disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public IEnumerable<TEntity> GetAll()
        {
            return dbSet.ToList();
        }

    }
}
