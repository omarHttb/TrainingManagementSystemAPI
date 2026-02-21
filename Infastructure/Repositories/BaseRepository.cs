using Application.Consts;
using Application.RepositoryInterfaces;
using Infastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected AppDbContext _context;
        protected readonly DbSet<T> _dbSet;
        public BaseRepository(AppDbContext context)
        {
            _context = context;
            _dbSet = _context.Set<T>();
        }

        public async Task<T> AddAsync(T entity)
        {
            
            await _context.Set<T>().AddAsync(entity);
            return entity;

        }
  
        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.Where(criteria).ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int take, int skip)
        {
            return await _context.Set<T>().Where(criteria).Skip(skip).Take(take).ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? take, int? skip,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            return await query.ToListAsync();
        }

        public async Task<List<T>> AddRangeAsync(List<T> entities)
        {
            await _context.Set<T>().AddRangeAsync(entities);
            return entities;
        }


        public async Task<int> CountAsync()
        {
            return await _context.Set<T>().CountAsync();
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>> criteria)
        {
            return await _context.Set<T>().CountAsync(criteria);
        }

        async Task<List<T>> IBaseRepository<T>.GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take, Expression<Func<T, object>> orderBy = null,
            string orderByDirection = "ASC", string[] includes = null)
        {
            IQueryable<T> query = _context.Set<T>().Where(criteria);

            if (take.HasValue)
                query = query.Take(take.Value);

            if (skip.HasValue)
                query = query.Skip(skip.Value);

            if (orderBy != null)
            {
                if (orderByDirection == OrderBy.Ascending)
                    query = query.OrderBy(orderBy);
                else
                    query = query.OrderByDescending(orderBy);
            }

            if (includes != null)
                foreach (var include in includes)
                    query = query.Include(include);

            return await query.ToListAsync();
        }

        public T Update(T entity)
        {
            _context.Update(entity);
            return entity;
        }

        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

    }
}
