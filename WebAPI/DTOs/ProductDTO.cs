namespace WebApi.DTOs
{
    public class ProductDTO
    {
        public int id { get; set; }
        public string name { get; set; }
        public string? thumnail { get; set; }
        public string? description { get; set; }
        public decimal? price { get; set; }
        public int? qty { get; set; }
        public int? categoryId { get; set; }
        public int? brandId { get; set; }
        public DateTime? CreatedAt { get; set; }






    }
}
