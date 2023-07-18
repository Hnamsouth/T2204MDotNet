
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace ExamSEM3.Entities
{
    [Table("Contacts")]
    public class Contacts
    {
        [Key]
        public int Id { get; set; }

        [Required,Column(TypeName ="nvarchar(255)")]
        public string ContactName { get; set; }

        [Required, Column(TypeName = "nvarchar(25)")]
        public string ContactNumber { get; set; }

        [Required, Column(TypeName = "nvarchar(255)")]
        public string GroupName { get; set; }

        [Required, Column(TypeName = "Date"), NotMapped]
        public DateOnly HireDate { get; set; }

        [Required, Column(TypeName = "Date"), NotMapped]
        public DateOnly Birthday { get; set; }


    }
}
