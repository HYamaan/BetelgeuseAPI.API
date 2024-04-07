using BetelgeuseAPI.Application.Repositories;
using BetelgeuseAPI.Domain.Common;
using BetelgeuseAPI.Persistence.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BetelgeuseAPI.Persistence.Repositories
{
    public class ReadRepository<TContext,T> : IReadRepository<T> where TContext : DbContext
        where T : BaseEntity
    {
        private readonly TContext _context;

        public ReadRepository(TContext context)
        {
            _context = context;
        }


        public DbSet<T> Table => _context.Set<T>();

        public IQueryable<T> GetAll(bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();
            return query;
        }

        public IQueryable<T> GetWhere(Expression<Func<T, bool>> method, bool tracking = true)
        {
            try
            {
                var query = Table.Where(method);
                if (!tracking)
                    query = query.AsNoTracking();
                return query;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<T> GetSingleAsync(Expression<Func<T, bool>> method, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(method);
        }
        public async Task<T> GetByIdAsync(string id, bool tracking = true)
        //=> await Table.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        //=> await Table.FindAsync(Guid.Parse(id));
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = Table.AsNoTracking();
            return await query.FirstOrDefaultAsync(data => data.Id == Guid.Parse(id));
        }

    }
}
