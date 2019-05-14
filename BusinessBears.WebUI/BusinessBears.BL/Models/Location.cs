using BusinessBears.Library.Abstracts;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessBears.Library
{
    /// <summary>
    /// A location object that has an inventory and can contain an order history. Also contains processing for orders
    /// </summary>
    public class Location
    {
        int _location_id;
        public int ID { get => _location_id; set => _location_id = value; }
        private List<InventoryItem> inventory;
        public List<InventoryItem> Inventory { get => inventory; set => inventory = value; }
        List<Order> orderHistory;

        /// <summary>
        /// AddProduct is used to stock the store with inventory
        /// </summary>
        /// <param name="p">A product. Location objects are typically spawned with a Bear product in inventory, so
        /// this will largely be used for adding training moduls</param>
        /// <param name="i">The initial quantity of the product that's being stockd.</param>
        public void AddProduct(InventoryItem item)
        {
            inventory.Add(item);
            //Console.WriteLine("Item added to inventory");
        }
        /// <summary>
        /// ProcessOrder handles functionality for placing orders
        /// </summary>
        /// <param name="order">It takes an Order object. The Order's 'bear' collection must be populated beforehand</param>
        /// <returns>The method returns an order with locationID attached for saving to DB</returns>
        public Order ProcessOrder(Order order)
        {
            bool upgradesQ = true;

            foreach (OrderBear bear in order.bears)
                foreach (var item2 in bear.upgrades)
                {
                    if (inventory.Find(x => x.Product.Name == item2.Product.Name) != null)
                    {
                        if (inventory.Find(x => x.Product.Name == item2.Product.Name).Quantity == 0)
                        {
                            upgradesQ = false;
                        }
                    }
                    else
                    {

                        Console.WriteLine("This location does not stock this training module.");
                    }
                }
            if (inventory.Find(x => x.Product.Name == "Bear").Quantity - order.bears.Count < 0 || upgradesQ == false)
            {
                Console.WriteLine("This location's inventory is too low to complete this order");
            }
            else
            {
                double finalprice = 0;
                foreach (OrderBear bear in order.bears)
                {
                    inventory.Find(x => x.Product.Name == "Bear").Quantity--;
                    foreach (var item in bear.upgrades)
                    {
                        inventory.Find(x => x.Product.Name == item.Product.Name).Quantity--;
                    }
                    finalprice += bear.getTotalPrice();
                }
                Console.WriteLine("Order placed! The bear(s) will cost ${0}", finalprice);
                order.Price = finalprice;

                order.LocationID = this._location_id;
                order.Ordertime = DateTime.Now;

            }
            return order;
        }
        //public Location()
        //{
        //    this.inventory = new Dictionary<string, InventoryItem>();
        //    inventory.Add("Bear", new InventoryItem(new Bear(), 0));
        //    this.orderHistory = new List<Order>();
        //}
    }
}
