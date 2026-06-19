namespace AbySalto.Mid.Domain.Data.DTO
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public double Price { get; set; }
        public double Rating { get; set; }
        public long Stock { get; set; }
    }
}
