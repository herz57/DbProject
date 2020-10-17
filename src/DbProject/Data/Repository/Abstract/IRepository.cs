using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DbProject.Data.Repository
{
    public interface IRepository<TEntity>
    {
        Task<TEntity> GetByIdAsync(object id);
        IQueryable<TEntity> GetByExp(Expression<Func<TEntity, bool>> expression);
        void InsertAsync(TEntity entity);
        void BulkInsertRangeAsync(IList<TEntity> entities);
        void UpdateAsync(TEntity entity);
        void BulkUpdateRangeAsync(IList<TEntity> entities);
        void DeleteAsync(TEntity entity);
        void BulkDeleteRangeAsync(IList<TEntity> entities);
        void SaveChangesAsync();

        IQueryable<TEntity> Table { get; }
        IQueryable<TEntity> TableNoTracking { get; }
    }
}
