using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BusinessBears.Library;

namespace BusinessBears.DA
{
    public static class Mapper
    {
        public static Library.Customer Map(Entities.Customer customer) => new Library.Customer
        {
            Id = customer.CustomerId,
            FirstName = customer.FirstName,
            LastName = customer.LastName,

        };

        public static Entities.Customer Map(Library.Customer customer) => new Entities.Customer
        {
            CustomerId = customer.Id,
            FirstName = customer.FirstName,
            LastName = customer.LastName,
        };

        public static Entities.Location Map(Library.Location location) => new Entities.Location
        {
            LocationId = location.ID,
            Inventory = Map(location.Inventory).ToList()
        };

        public static Library.Location Map(Entities.Location location) => new Library.Location
        {
            ID = location.LocationId,
            Inventory = Map(location.Inventory).ToList()
        };



        public static Library.InventoryItem Map(Entities.Inventory invitem) => new Library.InventoryItem
        {
           ID = invitem.InventoryId,
           Quantity = invitem.Quantity,
           Product = Map(invitem.Product)
        };

        public static Entities.Inventory Map(Library.InventoryItem invitem) => new Entities.Inventory
        {
            InventoryId = invitem.ID,
            Quantity = invitem.Quantity,
            Product = Map(invitem.Product)
        };

        public static Library.Training Map(Entities.Product product) => new Library.Training
        {
            ID = product.ProductId,
            Name = product.ProductName,
            Price = Convert.ToDouble(product.DefPrice)
        };

        public static Entities.Product Map(Library.Training product) => new Entities.Product
        {
            ProductId = product.ID,
            ProductName = product.Name,
            DefPrice = Convert.ToDecimal(product.Price)
        };

        public static Entities.Orders Map(Library.Order order) => new Entities.Orders
        {
            OrderId = order.ID,
            CreatedAt = order.Ordertime,
            PriceTag = Convert.ToDecimal(order.Price),
            CustomerId = order.CustomerID,
            LocationId = order.LocationID,
            Customer = Map(order.Customer),
            Location = Map(order.Location),
            SoldBears = Map(order.bears).ToList()
        };

        public static Library.Order Map(Entities.Orders order) => new Library.Order
        {
            ID = order.OrderId,
            Ordertime = order.CreatedAt,
            Price = Convert.ToDouble(order.PriceTag),
            CustomerID = order.CustomerId,
            LocationID = order.LocationId,
            Customer = Map(order.Customer),
            Location = Map(order.Location),
            bears = Map(order.SoldBears).ToList()
        };

        public static Entities.SoldBears Map(Library.OrderBear bear) => new Entities.SoldBears
        {
            OrderId = bear.OrderId,
            SoldTraining = Map(bear.upgrades).ToList()
        };

        public static Library.OrderBear Map(Entities.SoldBears bear) => new Library.OrderBear
        {
            OrderId = bear.OrderId,
            upgrades = Map(bear.SoldTraining).ToList()
        };

        public static Entities.SoldTraining Map(Library.TrainingContainer tc) => new Entities.SoldTraining
        {
            Product = Map(tc.Product),
            TrainingId = tc.ID
        };

        public static Library.TrainingContainer Map(Entities.SoldTraining tc) => new Library.TrainingContainer
        {
            Product = Map(tc.Product),
            ID = tc.TrainingId
        };






        //public static Entities.Review Map(Library.Models.Review review) => new Entities.Review
        //{
        //    Id = review.Id,
        //    ReviewerName = review.ReviewerName,
        //    Score = review.Score ?? throw new ArgumentException("review score cannot be null.", nameof(review)),
        //    Text = review.Text
        //};

        public static IEnumerable<Library.Customer> Map(IEnumerable<Entities.Customer> customers) =>
            customers.Select(Map);

        public static IEnumerable<Entities.Customer> Map(IEnumerable<Library.Customer> customers) =>
            customers.Select(Map);

        public static IEnumerable<Entities.Location> Map(IEnumerable<Library.Location> locations) =>
            locations.Select(Map);
        public static IEnumerable<Library.Location> Map(IEnumerable<Entities.Location> locations) =>
            locations.Select(Map);

        public static IEnumerable<Library.InventoryItem> Map(IEnumerable<Entities.Inventory> invitems) =>
            invitems.Select(Map);

        public static IEnumerable<Entities.Inventory> Map(IEnumerable<Library.InventoryItem> invitems) =>
           invitems.Select(Map);

        public static IEnumerable<Entities.Product> Map(IEnumerable<Library.Training> invitems) =>
           invitems.Select(Map);

        public static IEnumerable<Library.Training> Map(IEnumerable<Entities.Product> invitems) =>
           invitems.Select(Map);

        public static IEnumerable<Library.Order> Map(IEnumerable<Entities.Orders> orders) =>
           orders.Select(Map);

        public static IEnumerable<Entities.Orders> Map(IEnumerable<Library.Order> orders) =>
           orders.Select(Map);

        public static IEnumerable<Entities.SoldBears> Map(IEnumerable<Library.OrderBear> orderbears) =>
           orderbears.Select(Map);

        public static IEnumerable<Library.OrderBear> Map(IEnumerable<Entities.SoldBears> orderbears) =>
           orderbears.Select(Map);

        public static IEnumerable<Entities.SoldTraining> Map(IEnumerable<Library.TrainingContainer> tcs) =>
           tcs.Select(Map);

        public static IEnumerable<Library.TrainingContainer> Map(IEnumerable<Entities.SoldTraining> tcs) =>
           tcs.Select(Map);

        //public static IEnumerable<Library.Models.Review> Map(IEnumerable<Entities.Review> reviews) =>
        //    reviews.Select(Map);

        //public static IEnumerable<Entities.Review> Map(IEnumerable<Library.Models.Review> reviews) =>
        //    reviews.Select(Map);
    }
}
