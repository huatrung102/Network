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
using System.Data.Entity.Migrations;
using System.Data.Entity.Core.Objects;
using static Network.Domain.Enum.EType;
using RefactorThis.GraphDiff;

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
            catch (Exception ex)
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

        public virtual bool Update(TEntity entityToUpdate)
        {
            try
            {
                //http://stackoverflow.com/questions/23201907/asp-net-mvc-attaching-an-entity-of-type-modelname-failed-because-another-ent
                // context.Entry(entityToUpdate).State = EntityState.Modified;
                context.Set<TEntity>().AddOrUpdate(entityToUpdate);
                Commit();
                return true;
            }
            catch (NWException ex)
            {
                //throw ex;
            }
            return false;
        }

        public bool UpdateWithChilds(TEntity entityToUpdate, HashSet<Type> childTypes)
        {
            try
            {
                foreach (var entry in context.ChangeTracker.Entries<TEntity>())
                {
                    
                    // if (entry.State == EntityState.Added && entry.Entity != entityToUpdate)
                    ///*
                    if (entry.Entity != entityToUpdate)
                    {
                        if (childTypes == null || childTypes.Count == 0)
                        {
                            entry.State = EntityState.Unchanged;
                        }
                        else
                        {
                            // request object type from context because we might got reference to dynamic proxy
                            // and we wouldn't want to handle Type of dynamic proxy
                            Type entityType = ObjectContext.GetObjectType(entry.Entity.GetType());
                            // if type is not child type than it should not be saved so mark it as unchanged
                            if (childTypes.Contains(entityType))
                            {
                                entry.State = EntityState.Unchanged;
                            }
                            else
                            {                                
                                entry.State = EntityState.Modified;
                            }
                        }
                    }
                   // */
                }
                // context.Entry(entityToUpdate).State = EntityState.Modified;
                //  context.Set<TEntity>().AddOrUpdate(entityToUpdate);
                Commit();
                return true;
            }
            catch (NWException ex)
            {
                //throw ex;
            }
            return false;
        }

        public virtual bool UpdateWithChildsNew(TEntity entityToUpdate, HashSet<Type> childTypes)
        {
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
        //http://stackoverflow.com/questions/21426884/generic-repository-to-update-an-entire-aggregate
        private static void CheckForEntitiesWithoutStateInterface(NetworkContext context)
        {
            var entitiesWithoutState =
            from e in context.ChangeTracker.Entries()
            where !(e.Entity is IObjectWithState)
            select e;

            if (entitiesWithoutState.Any())
            {
                throw new NotSupportedException("All entities must implement IObjectWithState");
            }
        }
        private static EntityState ConvertState(State state)
        {
            switch (state)
            {
                case State.Added:
                    return EntityState.Added;
                case State.Deleted:
                    return EntityState.Deleted;
                case State.Modified:
                    return EntityState.Modified;
                case State.Unchanged:
                    return EntityState.Unchanged;
                default:
                    return EntityState.Unchanged;
            }

        }

        public bool UpdateWithChilds<TEntityState>(TEntityState entityToUpdate, HashSet<Type> childTypes) where TEntityState : BaseEntity, IObjectWithState
        {
            throw new NotImplementedException();
        }
    }
}
