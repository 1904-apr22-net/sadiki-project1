using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessBears.WebUI.Models
{
    public class OrderViewModel
    {
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "Order ID")]
        public int ID { get; set; }

        public CustomerViewModel Customer { get; set; }
        public LocationViewModel Location { get; set; }
        public int LocationID { get; set; }
        public int CustomerID { get; set; }
        public DateTime Ordertime {get; set;}
        public double Price { get; set; }
        [Display(Name = "Bear #")]
        public int BearNumber { get; set; }
        public IEnumerable<SoldBearsViewModel> SoldBears { get; set; }
    }
}
