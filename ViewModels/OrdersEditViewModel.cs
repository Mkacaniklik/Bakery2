using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bakery2.Models;

namespace Bakery2.ViewModels
{
    public class OrdersEditViewModel
    {

        public IList<Customer> Customers { get; set; }
        public string SearchString { get; set; }

        public string SearchString1 { get; set; }
    }
}
