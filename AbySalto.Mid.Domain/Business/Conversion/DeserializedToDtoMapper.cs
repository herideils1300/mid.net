using AbySalto.Mid.Domain.Data.DTO;
using AbySalto.Mid.Domain.Abstraction.Conversion;
using AbySalto.Mid.Domain.Data.Deserialized;

namespace AbySalto.Mid.Domain.Business.Conversion
{
    public class DeserializedToDtoMapper : IMapper<ProductDeserialized, ProductDto>
    {

        public ProductDto Map(ProductDeserialized entity)
        {
            ProductDto item = new ProductDto();

            item.Id = entity.id;
            item.Title = entity.title;
            item.Description = entity.description;
            item.Price = entity.price;
            item.Stock = entity.stock;

            return item;
        }
    }
}
