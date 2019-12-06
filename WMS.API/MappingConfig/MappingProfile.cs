using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using WMS.Domain;
using WMS.Service.Definitions.Dtos;

namespace WMS.API.MappingConfig
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Product
            CreateMap<ProductDto, Product>()
                //.ForMember(x => x.Name, y => y.MapFrom(z => z.Title))
                ;
            CreateMap<Product, ProductDto>()
                //.ForMember(x => x.Title, y => y.MapFrom(z => z.Name))
                ;
        }
    }
}
