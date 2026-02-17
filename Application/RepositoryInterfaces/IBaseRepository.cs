using Application.Consts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.RepositoryInterfaces
{
    public interface IBaseRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);

        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[] includes = null);

        Task<List<T>> GetAllAsync();

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, string[] includes = null);
        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int skip, int take);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
    Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending, string[] includes = null);

        Task<List<T>> FindAllAsync(Expression<Func<T, bool>> criteria, int? skip, int? take,
            Expression<Func<T, object>> orderBy = null, string orderByDirection = OrderBy.Ascending);



        Task<T> AddAsync(T entity);

        Task<List<T>> AddRangeAsync(List<T> entities);

        T Update(T entity);
        void Delete(T entity);

    }
}
