using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2204MDotNetCore.Entities
{
    public class Brand
    {
        [Key]
        public int Id { get; set; }

        [Required,StringLength(100),MinLength(3)]
        public string Name { get; set; }

        [Column(TypeName ="Text")]
        public String? Description { get; set; }

        public ICollection<Product> Products { get; set; }
    }
}
