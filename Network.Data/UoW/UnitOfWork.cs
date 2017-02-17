using Network.Data.Context;
using System;



namespace Network.Data.UoW
{
    /// <summary>
    /// Unit of work corner
    /// </summary>
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        #region fields
        private readonly NetworkContext _dbContext;
                
        #endregion

        #region ctor
        //We will dependency injection here
        public UnitOfWork()
        {
            this._dbContext = new NetworkContext();
        }
        #endregion

        #region IUnitOfWork member
        public void Commit()
        {
            _dbContext.SaveChanges();
        }

        #endregion

        #region Instance members
        public NetworkContext dbContext
        {
            get { return _dbContext; }
        }
        /*
        public T GetRepository<T>()
        {
            var repository = Activator.CreateInstance(typeof(T), _dbContext);
            return (T)repository;
        }
        */
        #endregion

        #region IDisposable members
        public void Dispose()
        {
            if (this._dbContext != null)
            {
                this._dbContext.Dispose();
            }
        }
        #endregion

    }
}
