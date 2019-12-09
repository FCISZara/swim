using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Swimming.Data.Repository
{
    public interface IRepository<TEntity>
           where TEntity : class, IEntity
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);

        Task<IQueryable<TEntity>> GetAllasync(bool overridQueryFilter = false);
        TEntity Get(Guid id);
        void Add(TEntity entity);
        void Update(TEntity entity);
        void Delete(TEntity entity);
        Task<int> SaveChanges();
        TEntity GetFirst(Expression<Func<TEntity, bool>> predicate);
        void Merge(TEntity persisted, TEntity current);
        int GetMax(Expression<Func<TEntity, bool>> predicate,
        Func<TEntity, int> MaxColumn);
        void UpdateWithoutGet(TEntity entity);
    }
}
