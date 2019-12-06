using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Threading.Tasks;
using WMS.Service.Definitions.Dtos;
namespace WMS.WCFService
{
    [ServiceContract]
    public interface IMainService
    {
        [OperationContract]
        Task<ProductDto> AddProduct(ProductDto model);

        [OperationContract]
        [WebInvoke(Method = "GET", ResponseFormat = WebMessageFormat.Json,
            BodyStyle = WebMessageBodyStyle.Bare, UriTemplate = "Products")]
        Task<IEnumerable<ProductDto>> GetProducts();
    }
}
