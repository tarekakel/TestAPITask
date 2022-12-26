using Contracts.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Repositories
{
    public interface IBaseRepository<T> where T : class
    {

        Task<IQueryable<T>> GetAllAsync(PageRequestDto pageRequestDto, Expression<Func<T, bool>>? criteria = null, string[]? includes = null, string[]? thenIncludes = null);
        Task<T> GetByIdAsync(int id);
        Task<int> CountAsync(Expression<Func<T, bool>>? criteria = null);
        T UpdateAsync(T entity);
        Task<T> AddAsync(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[]? includes, string[]? thenInclude);
    }
}
