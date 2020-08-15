using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
namespace Repository
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        protected readonly AppDbContext _context;
        protected readonly DbSet<TEntity> _entities;

        public Repository(AppDbContext context)
        {
            _context = context;
            _entities = context.Set<TEntity>();
        }

        public virtual async Task<TEntity> AddAsync(TEntity entity)
        {
            await _entities.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> AddRangeAsync(IEnumerable<TEntity> entities)
        {
            await _entities.AddRangeAsync(entities);
            await _context.SaveChangesAsync();
            return entities;
        }


        public virtual async Task<TEntity> UpdateAsync(TEntity entity)
        {
            _entities.Update(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> UpdateRangeAsync(IEnumerable<TEntity> entities)
        {
            _entities.UpdateRange(entities);
            await _context.SaveChangesAsync();
            return entities;
        }



        public virtual async Task RemoveAsync(TEntity entity)
        {
            _entities.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public virtual async Task RemoveRangeAsync(IEnumerable<TEntity> entities)
        {
            _entities.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public virtual async Task<int> CountAsync()
        {
            return await _entities.CountAsync();
        }

        public virtual async Task<bool> AnyAsync(Expression<Func<TEntity, bool>> predicate)
        {
            return await _entities.AnyAsync(predicate);
        }


        public virtual IEnumerable<TEntity> Find(Expression<Func<TEntity, bool>> predicate, bool eager = false)
        {
            return Query(eager).Where(predicate);
        }

        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool eager = false)
        {
            return await Query(eager).SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string navigationPropertyInclude)
        {
            return await _entities.Include(navigationPropertyInclude).SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string navigationPropertyInclude1,
            string navigationPropertyInclude2,
            string navigationPropertyInclude3)
        {
            return await _entities.Include(navigationPropertyInclude1).Include(navigationPropertyInclude2).Include(navigationPropertyInclude3).SingleOrDefaultAsync(predicate);
        }


        public virtual async Task<TEntity> GetSingleOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, string navigationPropertyInclude1,
           string navigationPropertyInclude2, string navigationPropertyInclude3, string navigationPropertyInclude4)
        {
            return await _entities.Include(navigationPropertyInclude1).Include(navigationPropertyInclude2).Include(navigationPropertyInclude3).Include(navigationPropertyInclude4).SingleOrDefaultAsync(predicate);
        }

        public virtual async Task<TEntity> GetFirstOrDefaultAsync(Expression<Func<TEntity, bool>> predicate, bool eager = false)
        {
            return await Query(eager).FirstOrDefaultAsync(predicate);
        }


        public virtual async Task<TEntity> GetAsync(int id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(Guid id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<TEntity> GetAsync(string id)
        {
            return await _entities.FindAsync(id);
        }

        public virtual async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _entities.ToListAsync();
        }

        public virtual IQueryable<TEntity> GetAllAsQuerable()
        {
            return _entities.AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAllAsQuerable(string navigationPropertyInclude)
        {
            return _entities.Include(navigationPropertyInclude).AsQueryable();
        }

        public virtual IQueryable<TEntity> GetAllAsQuerable(string navigationPropertyInclude1, string navigationPropertyInclude2)
        {
            return _entities.Include(navigationPropertyInclude1).Include(navigationPropertyInclude2).AsQueryable();
        }

        public virtual IQueryable<TEntity> Query(bool eager = false)
        {
            var query = _context.Set<TEntity>().AsQueryable();
            if (eager)
            {
                foreach (var property in _context.Model.FindEntityType(typeof(TEntity)).GetNavigations())
                    query = query.Include(property.Name);
            }
            return query;
        }
    }
}
