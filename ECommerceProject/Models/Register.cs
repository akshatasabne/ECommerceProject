using System.ComponentModel.DataAnnotations;
using System.Xml.Linq;

namespace ECommerceProject.Models
{
    public class Register
    {
        [Key]
        public int Uid { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        [Required]
        public string Confirmpwd { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string City { get; set; }
        [Required]
        public string State { get; set; }
        [Required]


        public int RoleId { get; set; }


    }
}
