using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using WMS.DataAccess;
using WMS.Domain;
using WMS.Service.Definitions.Dtos;
using WMS.Service.Definitions.Services;

namespace WMS.Service.Implementations.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        public OrderService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<OrderDto> Add(OrderDto dto)
        {
            var order = mapper.Map<Order>(dto);
            var addedEntity = unitOfWork.OrderRepository.Add(order);
            await unitOfWork.Commit();
            dto.Id = addedEntity.Id;
            return dto;
        }

        public async Task<IEnumerable<OrderDto>> Get()
        {
            var orders = await unitOfWork.OrderRepository.Get();
            var dtos = mapper.Map<IEnumerable<OrderDto>>(orders);
            return dtos;
        }
    }
}
