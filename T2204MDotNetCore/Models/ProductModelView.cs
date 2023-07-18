using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;
using T2204MDotNetCore.Entities;

namespace T2204MDotNetCore.Models
{
    public class ProductModelView
    {
        [
         Required(ErrorMessage ="Vui long nhap ten san pham"),
         MinLength(3, ErrorMessage ="Ten sp phai dai hon 3 ky tu"),
         MaxLength(255),
         Display(Name="Ten san pham")
        ]
        public string Name { get; set; }

        [Required]
        public double Price { get; set; }
        [AllowNull]
        public string? Description { get; set; }

        [Display(Name="Select a category")]
        public int CategorId { get; set; }
        [DisplayName("Select a brand")]
        public int BrandId { get; set; }

        public List<Category>?  categories { get; set; }
        public List<Brand>? brands { get; set; }

        public IEnumerable<SelectListItem>? GetCategoryList()
        {
            return categories.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
        }

        public IEnumerable<SelectListItem>? GetBrandList()
        {
            return brands.Select(c => new SelectListItem
            {
                Value = c.Id.ToString(),
                Text = c.Name
            });
        }


    }
}
