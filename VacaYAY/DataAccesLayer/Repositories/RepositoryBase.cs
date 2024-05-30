using DataAccesLayer.Contracts;
using DataAccesLayer.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Repositories
{
    public abstract class RepositoryBase<T> : IRepositoryBase<T> where T : class
        {
            protected ApplicationDbContext ApplicationDbContext;
            public RepositoryBase(ApplicationDbContext applicationDbContext)
                => ApplicationDbContext = applicationDbContext;

            public void Create(T entity)
            {
                ApplicationDbContext.Set<T>().Add(entity);
            }

            public void Delete(T entity)
            {
                ApplicationDbContext.Set<T>().Remove(entity);
            }

            public IQueryable<T> FindAll(bool trackChanges)
            {
                if (!trackChanges)
                    return ApplicationDbContext.Set<T>().AsNoTracking();
                else
                    return ApplicationDbContext.Set<T>();
            }


            public IQueryable<T> FindByCondition(Expression<Func<T, bool>> expression,
                  bool trackChanges) =>
                 !trackChanges ?
                  ApplicationDbContext.Set<T>()
                  .Where(expression)
                  .AsNoTracking() :
                  ApplicationDbContext.Set<T>()
                  .Where(expression);

        public async Task<(IEnumerable<T> entities, int count)> GetPaginatedAsync(IQueryable<T> query, int pageNumber, int pageSize)
        {
            var count = await query.CountAsync();

            var entities = await query
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();

            return(entities, count);
        }

        public void Update(T entity)
            {
                ApplicationDbContext.Set<T>().Update(entity);
            }
        }
}
