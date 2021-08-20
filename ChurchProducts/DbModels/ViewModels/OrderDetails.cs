using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbModels.ViewModels
{
    public class OrderDetails
    {
        public int Id { get; set; }
        [Required]
        [ForeignKey("product")]
        public int productIDFK { get; set; }
        public Product product { get; set; }
        [Required]
        [ForeignKey("order")]
        public int orderIDFK { get; set; }
        public Order order { get; set; }
    }
}
