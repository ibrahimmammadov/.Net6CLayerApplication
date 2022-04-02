using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Service.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IGenericRepo<T> _repo;
        private readonly IUnitOfWork _unitOfWork;

        public Service(IGenericRepo<T> repo, IUnitOfWork unitOfWork)
        {
            _repo = repo;
            _unitOfWork = unitOfWork;
        }
        public async Task<T> AddAsync(T entity)
        {
            await _repo.AddAsync(entity);
            await _unitOfWork.CommitAsync();
            return entity;
        }

        public async Task<IEnumerable<T>> AddRangeAsync(IEnumerable<T> entities)
        {
            await _repo.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            return entities;
        }

        public async Task<bool> AnyAsync(Expression<Func<T, bool>> expression)
        {
           return await _repo.AnyAsync(expression);
            
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
           return await _repo.GetAll().ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {

           var check = await _repo.GetByIdAsync(id);
            if (check is null)
            {
                throw new NotFoundException($"{typeof(T).Name} not found");
            }
            return check;
        }

        public async Task RemoveAsync(T entity)
        {
            _repo.Remove(entity);
             await _unitOfWork.CommitAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<T> entities)
        {
            _repo.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
        }

        public async Task UpdateAsync(T entity)
        {
            _repo.Update(entity);
            await _unitOfWork.CommitAsync();
        }

        public IQueryable<T> Where(Expression<Func<T, bool>> expression)
        {
            return _repo.Where(expression);
        }
    }
}
