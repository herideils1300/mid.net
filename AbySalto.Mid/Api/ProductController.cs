using System.Security.Cryptography.Xml;
using AbySalto.Mid.Application.Interfaces.Networking;
using AbySalto.Mid.Application.Products.Networking;
using AbySalto.Mid.Domain.Business.Logging;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Domain.Data.Model;
using AbySalto.Mid.Infrastructure.Products.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.Primitives;

namespace AbySalto.Mid.WebApi.ApiControllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IClient<ParamsModel, ProductDto[]> _paginationClient;
        private readonly FavouritesRepository _favRepo;
        private readonly IClient<int, ProductDto> _singleElementClient;
        private readonly ErrorWriter _errorLogger;
        private readonly IMemoryCache _cache;
        public ProductController(FavouritesRepository favRepo,
            IClient<ParamsModel, ProductDto[]> paginationClient,
            IClient<int, ProductDto> singleElementClient,
            ErrorWriter errorLogger,
            IMemoryCache cache)
        {
            this._paginationClient = paginationClient;
            this._singleElementClient = singleElementClient;
            _favRepo = favRepo;
            _errorLogger = errorLogger;
            _cache = cache;
        }

        [HttpPost("GetPage")]
        public async Task<ActionResult<ProductDto[]>> GetByParams([FromBody] ParamsModel paramsModel)
        {
            try
            {
                string key = $"{paramsModel.Page}.{paramsModel.Querry}.{paramsModel.OrderBy}.{paramsModel.SortElements}";

                if (_cache.TryGetValue(key, out object value))
                {
                    ProductDto[] previousDtos = value as ProductDto[];
                    return previousDtos;
                }

                ProductDto[] dtos = await _paginationClient.SendWithResult(paramsModel);

                _cache.GetOrCreate(key, (entry) =>
                {
                    entry.AbsoluteExpirationRelativeToNow = TimeSpan.FromMinutes(3);
                    return dtos;
                });

                return dtos;
            }
            catch (Exception e)
            {
                _errorLogger.LogException(e);
                return new StatusCodeResult(500);
            }
        }

        [HttpPost("Favourites/Add")]
        public async Task<ActionResult> PostFavouriteToUser([FromBody] UserProductDto dto)
        {
            try
            {
                ProductDto product = await _singleElementClient.SendWithResult(dto.ProductId);
                var result = _favRepo.PostFavourite(dto, product);

                if (result != null)
                {
                    return Ok();
                }

                return NotFound();
            }
            catch (Exception e)
            {

                _errorLogger.LogException(e);
                return new StatusCodeResult(500);
            }
        }

    }
}
