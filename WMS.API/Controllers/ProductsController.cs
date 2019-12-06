using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Http.Description;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WMS.Service.Definitions.Dtos;
using WMS.Service.Definitions.Services;

namespace WMS.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService productService;

        public ProductsController(IProductService productService)
        {
            this.productService = productService;
        }

        [HttpPost("")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> Post(ProductDto product)
        {
            var result = await productService.Add(product);
            return Ok(result);
        }

        [HttpGet("")]
        [ResponseType(typeof(IEnumerable<IEnumerable<ProductDto>>))]
        public async Task<IActionResult> Get()
        {
            var result = await productService.Get();
            return Ok(result);
        }
    }
}