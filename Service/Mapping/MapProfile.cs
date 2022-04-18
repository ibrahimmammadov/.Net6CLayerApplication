using AutoMapper;
using Core;
using Core.DTOs;
using Core.DTOsToken;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Mapping
{
    public class MapProfile:Profile
    {
        public MapProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
            CreateMap<Category, CategoryDto>().ReverseMap();
            CreateMap<ProductFeature, PFeatureDto>().ReverseMap();
            CreateMap<Product, ProdWithCatDto>();
            CreateMap<Category, CategoryWithProdDto>();
            CreateMap<ProductDto, Product>().ReverseMap();
            CreateMap<UserAppDto, UserApp>().ReverseMap();
        }
    }
}
