using BusinessBears.DA;
using BusinessBears.DA.Entities;
using BusinessBears.Library;
using BusinessBears.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OrderReviews.DataAccess.Repositories
{
    /// <summary>
    /// A repository managing data access for order objects and their review members,
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class OrderRepository : IOrderRepository
    {
        private readonly BBearContext  _dbContext;

        private readonly ILogger<OrderRepository> _logger;

        /// <summary>
        /// Initializes a new order repository given a suitable order data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public OrderRepository(BBearContext dbContext, ILogger<OrderRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all orders with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of orders</returns>
        public IEnumerable<BusinessBears.Library.Order> GetOrders()
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Orders> items = _dbContext.Orders.AsNoTracking();

            return Mapper.Map(items);
        }

        /// <summary>
        /// Get a order by ID, including any associated reviews.
        /// </summary>
        /// <returns>The order</returns>
        public BusinessBears.Library.Order GetOrderById(int id)
        {
            Orders order = _dbContext.Orders
                .AsNoTracking().First(r => r.OrderId == id);
            return Mapper.Map(order);
        }

        /// <summary>
        /// Add a order, including any associated reviews.
        /// </summary>
        /// <param name="order">The order</param>
        public void AddOrder(BusinessBears.Library.Order order)
        {
            if (order.ID != 0)
            {
                _logger.LogWarning("Order to be added has an ID ({orderId}) already: ignoring.", order.ID);
            }

            _logger.LogInformation($"Adding order");

            Orders entity = Mapper.Map(order);
            entity.OrderId = 0;
            _dbContext.Add(entity);
        }

        /// <summary>
        /// Delete a order by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="orderId">The ID of the order</param>
        //public void DeleteOrder(int orderId)
        //{
        //    _logger.LogInformation("Deleting order with ID {orderId}", orderId);
        //    Order entity = _dbContext.Order.Find(orderId);
        //    _dbContext.Remove(entity);
        //}

       

     

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        public void Save()
        {
            _logger.LogInformation("Saving changes to the database");
            _dbContext.SaveChanges();
        }

        #region IDisposable Support
        private bool disposedValue = false; // To detect redundant calls

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    _dbContext.Dispose();
                }

                disposedValue = true;
            }
        }

        // This code added to correctly implement the disposable pattern.
        public void Dispose() => Dispose(true);
        #endregion
    }
}
