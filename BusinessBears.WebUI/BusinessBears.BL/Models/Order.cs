using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessBears.Library
{
    public class Order
    { 
        int customer_id;
        int location_id;
        double _price;
        public double Price { get => _price; set => _price = value; }
        public int LocationID { get => location_id; set => location_id = value; }
        public int CustomerID { get => customer_id; set => customer_id = value; }
        public Location Location { get; set; }
        public Customer Customer { get; set; }
        public List<OrderBear> bears;
        private DateTime _ordertime;
        public DateTime Ordertime { get => _ordertime; set => _ordertime = value; }
        public int ID { get; set; }

     

    }
}
