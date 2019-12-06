using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WMS.DataAccess;
using WMS.Domain;
using WMS.Service.Definitions.Dtos;
using WMS.Service.Definitions.Services;

namespace WMS.Service.Implementations.Services
{
    public class ProductService : IProductService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public ProductService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ProductDto> Add(ProductDto dto)
        {
            var product = mapper.Map<Product>(dto);
            unitOfWork.ProductRepository.Add(product);
            await unitOfWork.Commit();
            dto.Id = product.Id;
            return dto;
        }

        public async Task<IEnumerable<ProductDto>> Get()
        {
            var products = await unitOfWork.ProductRepository.Get();
            var dtos = mapper.Map<IEnumerable<ProductDto>>(products);
            return dtos;
        }
    }
}
