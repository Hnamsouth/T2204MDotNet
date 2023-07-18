using System.ComponentModel.DataAnnotations;
using T2204MDotNetCore.Entities;

namespace T2204MDotNetCore.Models
{
    public class CategoryModelView
    {
        [Required(ErrorMessage = "Vui long nhap danh muc")]
        [MinLength(3, ErrorMessage = "Vui lòng nhập tối thiểu 6 ký tự")]
        [MaxLength(255)]
        [Display(Name = "Tên danh mục")]
        public string Name { get; set; }

        public List<Product>? products { get; set; }
    }
}
