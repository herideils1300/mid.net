using AbySalto.Mid.Application.Networking;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Domain.Data.Model;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly GetFilteredProductsClient _client;
        public ProductController(GetFilteredProductsClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ItemDto[]> GetByParams([FromBody] ParamsModel paramsModel)
        {
            return await _client.SendWithResult(paramsModel);
        }
    }
}
