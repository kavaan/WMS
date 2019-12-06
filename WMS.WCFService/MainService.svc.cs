using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using WMS.Service.Definitions.Dtos;
using WMS.Service.Definitions.Services;
using WMS.WCFService.Exceptions;
using WMS.WCFService.MappingConfig;

namespace WMS.WCFService
{
    [AutomapServiceBehavior]
    [GlobalErrorBehavior(typeof(GlobalErrorHandler))]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall, ConcurrencyMode = ConcurrencyMode.Multiple)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public class MainService : IMainService
    {
        private readonly IProductService productService;

        public MainService(IProductService productService)
        {
            this.productService = productService;
        }

        public async Task<ProductDto> AddProduct(ProductDto model)
        {
            var result = await productService.Add(model);
            return result;
        }

        public async Task<IEnumerable<ProductDto>> GetProducts()
        {
            var products= await productService.Get();
            return products;
        }
    }
}
