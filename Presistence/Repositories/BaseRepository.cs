using Contracts.Shared;
using Domain;
using Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using Presentation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : class
    {
        protected RepositoryDbContext _context;

        public BaseRepository(RepositoryDbContext context)
        {
            _context = context;
        }

        public async Task<int> CountAsync(Expression<Func<T, bool>>? criteria = null)
        {
            return await _context.Set<T>().CountAsync();
        }


        //this method is generic for all entites we just call it based on entity
        public async Task<IQueryable<T>> GetAllAsync(PageRequestDto pageRequestDto, Expression<Func<T, bool>>? criteria = null, string[]? includes = null, string[]? thenIncludes = null)
        {

            IQueryable<T> query = _context.Set<T>();

            if (includes is not null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);


            if (includes is not null)
                foreach (var incluse in thenIncludes)
                    query = query.Include(incluse);  
            if (criteria is not null)
            {
                query = query.Where(criteria).AsQueryable();
            }
            query = query.Skip(pageRequestDto.First).Take(pageRequestDto.Rows);

            return await Task.FromResult(query);

        }

        public async Task<T> GetByIdAsync(int id) => await _context.Set<T>().FindAsync(id);

        public async Task<T> AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            return entity;
        }

        public T UpdateAsync(T entity)
        {
            _context.Update(entity);
            return entity;
        }
        public async Task<T> FindAsync(Expression<Func<T, bool>> criteria, string[]? includes, string[]? thenInclude)
        {
            IQueryable<T> query = _context.Set<T>();

            if (includes != null)
                foreach (var incluse in includes)
                    query = query.Include(incluse);

            if (thenInclude is not null)
                foreach (var incluse in thenInclude)
                    query = query.Include(incluse);

            return await query.SingleOrDefaultAsync(criteria);
        }
    }
}

