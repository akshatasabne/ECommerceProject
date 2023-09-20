using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace ECommerceProject.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string? Name { get; set; }
        [Required]

        public double Price { get; set; }
        [Required]

        public string? Imageurl { get; set; }
        [Required]
        [Display(Name = "Cname")]

        public int Cid { get; set; }
        [Display(Name = "Cname")]
        public string? Cname { get; set; }
        [NotMapped]
        public int Quantity { get;set; }
        [NotMapped]
        public int CartId { get; set; }
        [NotMapped]
        public int Oid { get; set; }
        [NotMapped] 
        public DateTime? Date_time { get; set; }  

    }
}
