using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AbySalto.Mid.Application.Interfaces.Networking;
using AbySalto.Mid.Domain.Abstraction.Conversion;
using AbySalto.Mid.Domain.Business.Conversion;
using AbySalto.Mid.Domain.Business.Networking;
using AbySalto.Mid.Domain.Data.Deserialized;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Domain.Data.Model;
using Newtonsoft.Json;

namespace AbySalto.Mid.Application.Products.Networking
{
    public class GetProductByIdClient : IClient<int, ProductDto>
    {
        private readonly IMapper<ProductDeserialized, ProductDto> mapper;
        private readonly UriFactory _uriFactory;
        private readonly string rootPage = "dummyjson.com";

        public GetProductByIdClient()
        {
            _uriFactory = new UriFactory(rootPage);
            mapper = new DeserializedToDtoMapper();
        }

        public async Task<ProductDto> SendWithResult(int id)
        {
            string uri = _uriFactory.GetUriForSingleElement(id);

            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync(uri);
                Stream bytes = result.Content.ReadAsStream();

                byte[] buffer = new byte[bytes.Length];
                bytes.ReadExactly(buffer);
                string json = Encoding.UTF8.GetString(buffer);

                ProductDeserialized item = JsonConvert.DeserializeObject<ProductDeserialized>(json) ?? throw new Exception("Json unable to deserialize due to validity.");
                ProductDto dto = mapper.Map(item);

                return dto;

            }
        }

    }
}
