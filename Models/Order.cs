using Bakery2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;




namespace Bakery2.Models
{
    public class Order
    {
        [Required]
        public long OrderId { get; set; }

        [Required]
        public long ProductId { get; set; }
        public Products Products { get; set; } = default!;

        [Required]
        public long CustomerId { get; set; }

        public Customer Customer { get; set; } = default!;


      
    }
}
