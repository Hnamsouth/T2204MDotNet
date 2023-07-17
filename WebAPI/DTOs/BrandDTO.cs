using WebApi.Entities;

namespace WebApi.DTOs
{
    public class BrandDTO
    {
        public int? id { get; set; }
        public string name { get; set; }
        public string logo { get; set; }

        public List<ProductDTO>? products { get; set; }
    }
}
