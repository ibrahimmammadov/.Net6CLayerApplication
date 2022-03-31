using AutoMapper;
using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : CBaseController
    {
        private readonly IMapper mapper;
        private readonly IService<Product> service;
        private readonly IProductService productService;

        public ProductsController(IMapper _mapper, IService<Product> _service, IProductService _productService)
        {
            mapper = _mapper;
            service = _service;
            productService = _productService;
        }


        //GET api/products/GetProductWithCat
        [HttpGet("[action]")]
        public async Task<IActionResult> GetProductWithCat()
        {
            return CreatActionResult(await productService.GetProductWithCateg());
        }


        [HttpGet]
        public async Task<IActionResult> AllAsync()
        {
            var product = await service.GetAllAsync();
            var productdto = mapper.Map<List<ProductDto>>(product.ToList());
            //return Ok(CResponseDto<List<ProductDto>>.Success(200, productdto));
            return CreatActionResult(CResponseDto<List<ProductDto>>.Success(200,productdto));
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var product = await service.GetByIdAsync(id);
            var productdto = mapper.Map<ProductDto>(product);
            return CreatActionResult(CResponseDto<ProductDto>.Success(200,productdto));
        }


        [HttpPost]
        public async Task<IActionResult> Save(ProductDto dto)
        {
            var product = await service.AddAsync(mapper.Map<Product>(dto));
            var productdto = mapper.Map<ProductDto>(product);
            return CreatActionResult(CResponseDto<ProductDto>.Success(201,productdto));
        }


        [HttpPut]
        public async Task<IActionResult> Update(ProductDto dto)
        {
             await service.UpdateAsync(mapper.Map<Product>(dto));
            return CreatActionResult(CResponseDto<bool>.Success(204));
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> Remove(int id)
        {
            var product = await service.GetByIdAsync(id);
            await service.RemoveAsync(product);
            var productdto = mapper.Map<ProductDto>(product);
            return CreatActionResult(CResponseDto<bool>.Success(204));
        }


    }
}
