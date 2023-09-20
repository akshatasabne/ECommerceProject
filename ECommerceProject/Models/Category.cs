using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Category
    {
        [Key]
        [ScaffoldColumn(false)]

        public int Cid { get; set; }
        [Required]
        public string? Cname { get; set; }
    }
}
