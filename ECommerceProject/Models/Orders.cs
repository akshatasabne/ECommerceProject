using System.ComponentModel.DataAnnotations;

namespace ECommerceProject.Models
{
    public class Orders
    {
       
        public int Oid { get; set; }
        public int Id { get; set; }
        public  int Uid { get; set; }
        public int Quantity { get; set; }

        public DateTime? Date_time { get; set; }
    }
}
