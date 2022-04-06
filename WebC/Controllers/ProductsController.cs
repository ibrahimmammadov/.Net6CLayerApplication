using AutoMapper;
using Core;
using Core.DTOs;
using Core.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using WebC.Filters;

namespace WebC.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IProductService _service;
        private readonly ICategoryService _categoryService;
        private readonly IMapper _mapper;

        public ProductsController(IProductService service, IMapper mapper, ICategoryService categoryService)
        {
            _service = service;
            _mapper = mapper;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
           var products = await _service.GetAllAsync();
            return View(products.TakeLast(10));
        }

        public async Task<IActionResult> Save()
        {
           var cat = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(cat, "Id", "Name");
            
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Save(ProductDto productDto)
        {
            if (ModelState.IsValid)
            { 
              await _service.AddAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction("Index");
            }
            var cat = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(cat, "Id", "Name");

            return View();
        }

        [ServiceFilter(typeof(NotFoundFilter<Product>))]
        public async Task<IActionResult> Update(int id)
        {

            var cat = await _categoryService.GetAllAsync();

            var produpdt = await _service.GetByIdAsync(id);
            ViewBag.categories = new SelectList(cat, "Id", "Name",produpdt.Id);

            return View(_mapper.Map<ProductDto>(produpdt));
        }

        [HttpPost]
        public async Task<IActionResult> Update(ProductDto productDto)
        {
            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(_mapper.Map<Product>(productDto));
                return RedirectToAction("Index");
            }
            var cat = await _categoryService.GetAllAsync();
            ViewBag.categories = new SelectList(cat, "Id", "Name");
            
            return View(productDto);
        }

    }
}
