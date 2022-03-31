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
    public class ProductService : Service<Product>, IProductService
    {
        private readonly IProductRepo _prorepo;
        private readonly IMapper _mapper;



        public ProductService(IGenericRepo<Product> repo, IUnitOfWork unitOfWork, IProductRepo prorepo, IMapper mapper) : base(repo, unitOfWork)
        {
            _prorepo = prorepo;
            _mapper = mapper;
        }

        public async Task<CResponseDto<List<ProdWithCatDto>>> GetProductWithCateg()
        {
            var prodwithcat = await _prorepo.GetProductWithCateg();
            var prodcatdto = _mapper.Map<List<ProdWithCatDto>>(prodwithcat);
            return  CResponseDto<List<ProdWithCatDto>>.Success(200, prodcatdto);
        }
    }
}
