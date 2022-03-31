using Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Repository.Repository
{
    public class GenericRepo<T> : IGenericRepo<T> where T : class
    {
        protected readonly AppDbContext _context;
        private readonly DbSet<T> _dbset;
        public GenericRepo(AppDbContext appDbContext )
        {
            _context = appDbContext;
           _dbset = _context.Set<T>();
        }

        public async Task AddAsync(T entity)
        {
             await _dbset.AddAsync(entity);
        }

        public async Task AddRangeAsync(IEnumerable<T> entities)
        {
            await _dbset.AddRangeAsync(entities);
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
            return await _dbset.AnyAsync(expression);
        }

        public IQueryable<T> GetAll()
        {
            return _dbset.AsNoTracking().AsQueryable();
        }

        public async Task<T> GetByIdAsync(int id)
        {
#pragma warning disable CS8603 // Possible null reference return.
            return await _dbset.FindAsync(id);
#pragma warning restore CS8603 // Possible null reference return.
        }

        public void Remove(T entity)
        {
           _dbset.Remove(entity);
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            _dbset.RemoveRange(entities);
        }

        public void Update(T entity)
        {
            _dbset.Update(entity);
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _dbset.Where(expression);
        }
    }
}
