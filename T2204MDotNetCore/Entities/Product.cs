using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace T2204MDotNetCore.Entities
{
    [Table("products")]
    public class Product
    {
        [Key]
        public int id { get; set; } // abtract property

        [Required, StringLength(50)]
        public String Name { get; set; }

        [Required]
        public double Price { get; set; }

        [Column(TypeName ="Text")]
        public String? Description { get; set; }

        //
        public  int CategorId { get; set; }

        [ForeignKey("CategorId")]
        public Category category { get; set; } 

        //
        public int BrandId { get; set; }
       
        [ForeignKey("BrandId")]
        public Brand brand { get; set; }
    }
}
