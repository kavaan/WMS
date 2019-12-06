using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WMS.Domain;
using WMS.Service.Definitions.Dtos;

namespace WMS.WCFService.MappingConfig
{
    public class AutomapBootstrap : Profile
    {
        public AutomapBootstrap()
        {
            //Product
            CreateMap<ProductDto, Product>()
                //.ForMember(x => x.Name, y => y.MapFrom(z => z.Title))
                ;
            CreateMap<Product, ProductDto>()
                // .ForMember(x => x.Title, y => y.MapFrom(z => z.Name))
                ;
        }
    }
}