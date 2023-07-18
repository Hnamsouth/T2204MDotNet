using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ExamSEM3.Models
{
    public class ContactViewModel
    {

        [Required,StringLength(255, ErrorMessage="Do dai qua muc quy dinh"),
         MinLength(3, ErrorMessage ="Do dai toi thieu la 3 ky tu" ),
         Display(Name ="Nhap Ten")]
        public string ContactName { get; set; }

        [Required, StringLength(20, ErrorMessage = "Do dai qua muc quy dinh"),
         MinLength(9, ErrorMessage = "Do dai toi thieu la 9 ky tu"),
         Display(Name = "Nhap So Dien Thoai")]
        public string ContactNumber { get; set; }

        [Required, StringLength(255, ErrorMessage = "Do dai qua muc quy dinh"),
         MinLength(3, ErrorMessage = "Do dai toi thieu la 3 ky tu"),
         Display(Name = "Nhap Ten")]
        public string GroupName { get; set; }

        [Required, Display(Name = "Nhap Ngay Thue")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime HireDate { get; set; }

        [Required, Display(Name = "Nhap Ngay Sinh")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime Birthday { get; set; }

    }
}
