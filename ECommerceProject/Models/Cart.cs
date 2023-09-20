using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Cart
    {
        [Key]
            public int CartId { get; set; }

            public int Uid { get; set; }
            public int Id { get; set; }
        [Required]
            public int Quantity { get; set; }



        

    }
}
