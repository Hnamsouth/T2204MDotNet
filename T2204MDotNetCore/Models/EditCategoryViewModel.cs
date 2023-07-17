using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace T2204MDotNetCore.Models
{
    public class EditCategoryViewModel
    {
        [Required]
        public int Id { get; set; }

        [Required,Display(Name= "Tên danh mục")]
        public string Name { get; set; }
    }
}
