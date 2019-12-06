using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WMS.Domain;
using WMS.Service.Definitions.Dtos;

namespace WMS.Service.Definitions.Services
{
    public interface IOrderService
    {
        Task<OrderDto> Add(OrderDto dto);
        Task<IEnumerable<OrderDto>> Get();
    }
}
