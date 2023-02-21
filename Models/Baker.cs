using Bakery2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;


namespace Bakery2.Models
{
    public class Baker
    {
        [Required]
        public long BakerId { get; set; }

        [Display(Name = "First Name")]
        [StringLength(10, MinimumLength = 3)]
        [Required]
        public string FirstName { get; set; } = default!;

        [Display(Name = "Last Name")]
        [StringLength(50, MinimumLength = 5)]
        [Required]
        public string LastName { get; set; } = default!;

        public string FullName
        {
            get { return string.Format("{0} {1}", FirstName, LastName); }
        }

       [InverseProperty(nameof(Products.Baker))]
        public ICollection<Products> ProductsAsChefBaker { get; set; } = default!;

    }
}