using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Swimming.Data.UnitOfWork
{

    public class UnitOfWork : IUnitOfWork
    {
        #region Members

        private readonly SwimmingContext _context;
    


        #endregion

        #region Constructor

        public UnitOfWork(SwimmingContext context)
        {
            _context = context;
        }

        #endregion

        #region IUnitOfWork Members     

        public async Task<int> SaveChanges()
        {
            SetIEntityFields();
            return await _context.SaveChangesAsync();
        }
        public int SaveChanges_notasync()
        {
            SetIEntityFields();
            return _context.SaveChanges();
        }

        public DbSet<TEntity> CreateSet<TEntity>()
            where TEntity : class
        {
            var set = _context.Set<TEntity>();
            return set;
        }

        #endregion

        #region IDisposable Members

        ////public void Dispose()
        ////{

        ////    //_context.Dispose();
        ////}

        #endregion

        #region Private Methods

        private void SetIEntityFields()
        {
            //var now = DateTime.Now;

            //_context.ChangeTracker.Entries<IEntity>()
            //.Where(e => e.State == EntityState.Added)
            //.ToList()
            //.ForEach(e =>
            //{
            //    e.Entity.Id = Guid.NewGuid();
            //    e.Entity.CreationDate = now;
            //    e.Entity.IsActive = true;
            //});
            //_context.ChangeTracker.Entries<IEntity>()
            //.Where(e => e.State == EntityState.Modified)
            //.ToList()
            //.ForEach(e =>
            //{
            //    e.Entity.ModificationDate = now;
            //});
            
        }
        public void ApplyCurrentValues<TEntity>(TEntity original, TEntity current) where TEntity : class
        {
            //((IEntity<int>)original).ModificationDate = DateTime.Now;
            ((IEntity)original).ModificationDate = DateTime.Now;
            //  ((IEntity)original).LastUpdatedUsername = _identityProvider.GetUsername();
            //  ((IEntity)original).LastUpdateBy = _identityProvider.GetUserId();
            //((IEntity)original).IsActive = true;

            //if it is not attached, attach original and set current values
            _context.Entry(original).CurrentValues.SetValues(current);
        }
        #endregion

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _context.Database.BeginTransactionAsync();
        }

        public async Task<DbSet<TEntity>> CreateSetasync<TEntity>() where TEntity : class
        {
            var set = _context.Set<TEntity>();
            return await Task.Run(() => set);
        }



        public void UpdateWithoutGet<TEntity>(TEntity entity) where TEntity : class
        {
            var dbSet = CreateSet<TEntity>();
            dbSet.Attach(entity);
            var entry = _context.Entry(entity);

        }

        public void PartialUpdate<TEntity>(TEntity entity, params Expression<Func<TEntity, object>>[] propsToUpdate) where TEntity : class
        {
            var dbSet = CreateSet<TEntity>();
            dbSet.Attach(entity);
            var entry = _context.Entry(entity);
            foreach (var prop in propsToUpdate)
                entry.Property(prop).IsModified = true;
        }
    }
}
