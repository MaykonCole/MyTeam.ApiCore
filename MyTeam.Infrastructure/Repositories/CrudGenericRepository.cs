using Microsoft.EntityFrameworkCore;
using MyTeam.Core.Interfaces;
using MyTeam.Infrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyTeam.Infrastructure.Repositories
{
    public abstract class CrudGenericRepository<T> : ICrudGenericRepository<T> where T : class
    {
        protected readonly ApplicationDbContext _context;

        protected CrudGenericRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<T> Get(long id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task Add(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
        }

        Task ICrudGenericRepository<T>.Update(T entidade)
        {
            throw new NotImplementedException();
        }

        Task ICrudGenericRepository<T>.Delete(T entidade)
        {
            throw new NotImplementedException();
        }
    }
}
