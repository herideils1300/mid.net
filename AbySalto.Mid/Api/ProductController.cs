using AbySalto.Mid.Application.Networking;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Outbound.Networking;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace AbySalto.Mid.WebApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiProductController : ControllerBase
    {
        private readonly GetAllProductsClient _client;
        public ApiProductController(GetAllProductsClient client)
        {
            _client = client;
        }

        [HttpGet]
        public async Task<ItemDto[]> GetProducts()
        {
            return await _client.SendWithResult("dummyjson.com", "/products");
        }
    }
}
