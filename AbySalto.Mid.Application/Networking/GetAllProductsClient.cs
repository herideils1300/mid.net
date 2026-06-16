using System.Text;
using AbySalto.Mid.Domain.Abstraction.Conversion;
using AbySalto.Mid.Domain.Abstraction.Networking;
using AbySalto.Mid.Domain.Business.Conversion;
using AbySalto.Mid.Domain.Business.Networking;
using AbySalto.Mid.Domain.Data.Deserialized;
using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Infrastructure.Outbound.Networking;
using Newtonsoft.Json;

namespace AbySalto.Mid.Application.Networking
{
    public class GetAllProductsClient : IClient<ItemDto[]>
    {
        private readonly IMapper<ItemDeserialized, ItemDto> _mapper;
        public GetAllProductsClient()
        {
            _mapper = new DeserializedToDtoMapper();
        }

        public async Task<ItemDto[]> SendWithResult(string root, string path, params KeyValuePair<string, string>[] args)
        {
            IUriBuilder uriBuilder = new UriBuilderImpl();

            uriBuilder.BuildProtocol(true);
            uriBuilder.BuildRoot(root);
            uriBuilder.BuildPath(path);
            uriBuilder.BuildArgs(args);

            string uri = uriBuilder.ReturnFullUri();

            using (HttpClient client = new HttpClient())
            {
                var result = await client.GetAsync(uri);
                Stream bytes = result.Content.ReadAsStream();

                byte[] buffer = new byte[bytes.Length];
                bytes.Read(buffer, 0, buffer.Length);
                string json = Encoding.UTF8.GetString(buffer);

                List<ItemDeserialized> items = JsonConvert.DeserializeObject<Root>(json)?.products ?? throw new Exception("Json unable to deserialize due to validity.");
                ItemDto[] dtos = items.Select(_mapper.Map).ToArray();

                return dtos;

            }
        }
    }
}
