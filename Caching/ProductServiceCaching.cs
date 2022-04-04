using AutoMapper;
using Core;
using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Caching.Memory;
using Service.Exceptions;
using System.Linq.Expressions;

namespace Caching
{
    public class ProductServiceCaching : IProductService
    {
        private const string CacheProductKey = "productChache";
        private readonly IProductRepo _productRepo;
        private readonly IMapper _mapper;
        private readonly IMemoryCache _memoryCache;
        private readonly IUnitOfWork _unitOfWork;


        public ProductServiceCaching(IProductRepo producRepo, IUnitOfWork unitOfWork, IMemoryCache memoryCache, IMapper mapper)
        {
            _productRepo = producRepo;
            _unitOfWork = unitOfWork;
            _memoryCache = memoryCache;
            _mapper = mapper;
            if (!_memoryCache.TryGetValue(CacheProductKey,out _))
            {
                _memoryCache.Set(CacheProductKey, _productRepo.GetAll().ToList());
            }
        }

        public async Task<Product> AddAsync(Product entity)
        {
           await _productRepo.AddAsync(entity);
           await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
            return entity;
        }

        public async Task<IEnumerable<Product>> AddRangeAsync(IEnumerable<Product> entities)
        {
            await _productRepo.AddRangeAsync(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
            return entities;
        }

        public  Task<bool> AnyAsync(Expression<Func<Product, bool>> expression)
        {
            return Task.FromResult(_memoryCache.Get<List<Product>>(CacheProductKey).Any(expression.Compile()));
        }

        public Task<IEnumerable<Product>> GetAllAsync()
        {
            return Task.FromResult(_memoryCache.Get<IEnumerable<Product>>(CacheProductKey));
        }

        public Task<Product> GetByIdAsync(int id)
        {
            var product =  _memoryCache.Get<List<Product>>(CacheProductKey).FirstOrDefault(x => x.Id == id);
            if (product is null)
            {
                throw new NotFoundException($"{typeof(Product).Name} not found");
            }
            return Task.FromResult(product);
        }

        public async Task<CResponseDto<List<ProdWithCatDto>>> GetProductWithCateg()
        {
           var prodwithcat = await _productRepo.GetProductWithCateg();
            var dto = _mapper.Map<List<ProdWithCatDto>>(prodwithcat);
            return await Task.FromResult(CResponseDto<List<ProdWithCatDto>>.Success(200, dto));
        }

        public async Task RemoveAsync(Product entity)
        {
             _productRepo.Remove(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public async Task RemoveRangeAsync(IEnumerable<Product> entities)
        {
             _productRepo.RemoveRange(entities);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public async Task UpdateAsync(Product entity)
        {
            _productRepo.Update(entity);
            await _unitOfWork.CommitAsync();
            await CacheAllProductAsync();
        }

        public IQueryable<Product> Where(Expression<Func<Product, bool>> expression)
        {
            return _memoryCache.Get<List<Product>>(CacheProductKey).Where(expression.Compile()).AsQueryable();
        }
        public async Task CacheAllProductAsync()
        {
           _memoryCache.Set(CacheProductKey,await _productRepo.GetAll().ToListAsync());
        }
    }
}