using DbProject.Data.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using EFCore.BulkExtensions;
using System.Threading.Tasks;

namespace DbProject.Data.Repository
{
    public class EfRepository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        private readonly AppDbContext _context;
        private DbSet<TEntity> _entity;

        public IQueryable<TEntity> Table => _entity;
        public IQueryable<TEntity> TableNoTracking => _entity.AsNoTracking();

        public EfRepository(AppDbContext context)
        {
            _context = context;
            _entity = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> GetByIdAsync(object id)
        {
            return await _entity.FindAsync(id);
        }

        public IQueryable<TEntity> GetByExp(Expression<Func<TEntity, bool>> expression)
        {
            return _entity.Where(expression);
        }

        public virtual async void InsertAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Add(entity);
            await _context.SaveChangesAsync();

        }
        public virtual async void BulkInsertRangeAsync(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

           await _context.BulkInsertAsync(entities);
        }

        public virtual async void UpdateAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Update(entity);
            await _context.SaveChangesAsync();

        }
        public virtual async void BulkUpdateRangeAsync(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _context.BulkUpdateAsync(entities);
        }

        public virtual async void DeleteAsync(TEntity entity)
        {
            if (entity == null)
                throw new ArgumentNullException(nameof(entity));

            _entity.Remove(entity);
            await _context.SaveChangesAsync();

        }
        public virtual async void BulkDeleteRangeAsync(IList<TEntity> entities)
        {
            if (entities == null)
                throw new ArgumentNullException(nameof(entities));

            await _context.BulkDeleteAsync(entities);
        }

        public async void SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
