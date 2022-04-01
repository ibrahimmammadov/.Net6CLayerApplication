using AutoMapper;
using Core;
using Core.DTOs;
using Core.Repositories;
using Core.Services;
using Core.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Services
{
    public class CategoryService : Service<Category>, ICategoryService
    {
        private readonly ICategoryRepo _catrepo;
        private readonly IMapper _mapper;

        public CategoryService(IGenericRepo<Category> repo, IUnitOfWork unitOfWork, IMapper mapper, ICategoryRepo catrepo) : base(repo, unitOfWork)
        {
            _mapper = mapper;
            _catrepo = catrepo;
        }

        public async Task<CResponseDto<CategoryWithProdDto>> GetSingleCategoryWithProdAsync(int categoryid)
        {
            var cat = await _catrepo.GetSingleCategoryWithProdAsync(categoryid);
            var catdto = _mapper.Map<CategoryWithProdDto>(cat);
            return CResponseDto<CategoryWithProdDto>.Success(200, catdto);
        }
    }
}
