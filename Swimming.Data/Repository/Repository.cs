using Microsoft.EntityFrameworkCore.Storage;
using Swimming.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Swimming.Data.Repository
{
    public class Repository<TEntity, TId> : IRepository<TEntity>
       where TEntity : class, IEntity
    {
        private readonly IUnitOfWork _unitOfWork;

        public Repository(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }
        public async Task<int> SaveChanges()
        {
            return await _unitOfWork.SaveChanges();
        }

        public async Task<IDbContextTransaction> BeginTransaction()
        {
            return await _unitOfWork.BeginTransaction();
        }

        public TEntity GetFirst(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                IQueryable<TEntity> query = GetAll().Where(predicate);
                return query.FirstOrDefault();
            }
            else
            {
                throw new ArgumentNullException("The <predicate> paramter is required.");
            }

        }
        public virtual void Merge(TEntity persisted, TEntity current)
        {
            _unitOfWork.ApplyCurrentValues(persisted, current);
        }

        public IQueryable<TEntity> GetAll()
        {
            
            return _unitOfWork.CreateSet<TEntity>();
        }
        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            if (predicate != null)
            {
                return GetAll().Where(predicate);
            }
            else
            {
                throw new ArgumentNullException("The <predicate> paramter is required.");
            }
        }
        //public TEntity Get(Guid id)
        //{
        //    return GetAll().SingleOrDefault(s => s.Id == id);
        //}
        public int GetMax(Expression<Func<TEntity, bool>> predicate,
           Func<TEntity, int> MaxColumn)
        {
            if (predicate != null)
            {
                return GetAll().Where(predicate).Select(MaxColumn).DefaultIfEmpty(0).Max();
            }
            else
            {
                throw new ArgumentNullException("The <predicate> paramter is required.");
            }
        }
        public void Add(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var dbSet = _unitOfWork.CreateSet<TEntity>();
            dbSet.Add(entity);

        }
        public void Update(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            var dbSet = _unitOfWork.CreateSet<TEntity>();
            dbSet.Update(entity);
        }

        public void UpdateWithoutGet(TEntity entity)
        {

            _unitOfWork.UpdateWithoutGet(entity);


        }

        public void PartialUpdate(TEntity entity, params Expression<Func<TEntity, object>>[] propsToUpdate)
        {
            _unitOfWork.PartialUpdate(entity, propsToUpdate);

        }

        public void Delete(TEntity entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }

            var dbSet = _unitOfWork.CreateSet<TEntity>();
            dbSet.Remove(entity);
        }

        //public void Dispose()
        //{
        //    _unitOfWork.Dispose();
        //}


        public async Task<IQueryable<TEntity>> GetAllasync(bool overridQueryFilter = false)
        {
            return await _unitOfWork.CreateSetasync<TEntity>();
        }


        public TEntity Get(Guid id)
        {
            return GetAll().FirstOrDefault(c => c.Id.Equals(id));
        }

    }
}