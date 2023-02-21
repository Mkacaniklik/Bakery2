using Bakery2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;




namespace Bakery2.Models
{
    public class Products
    {
        [Required]
        public long ProductsId { get; set; }

        [StringLength(100, MinimumLength = 3)]
        [Required]
        public string Name { get; set; } = default!;

        [Required]
        public int? Price { get; set; }




        public long BakerId { get; set; }
        [Display(Name = "Baker")]
        public Baker Baker { get; set; } = default!;

        public ICollection<Order> Orders { get; set; } = default!;

    }
}