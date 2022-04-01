using Core.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : CBaseController
    {
        private readonly ICategoryService _productService;

        public CategoriesController(ICategoryService productService)
        {
            _productService = productService;
        }

        [HttpGet("[action]/{id}")]
        public async Task<IActionResult> Get(int id)
        {
            return CreatActionResult(await _productService.GetSingleCategoryWithProdAsync(id));
        }
    }
}
