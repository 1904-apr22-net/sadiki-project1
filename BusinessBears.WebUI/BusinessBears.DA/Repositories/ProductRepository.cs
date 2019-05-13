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
    public class ProductRepository : IProductRepository
    {
        private readonly BBearContext  _dbContext;

        private readonly ILogger<ProductRepository> _logger;

        /// <summary>
        /// Initializes a new order repository given a suitable order data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public ProductRepository(BBearContext dbContext, ILogger<ProductRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all orders with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of orders</returns>
        public IEnumerable<BusinessBears.Library.Training> GetProducts()
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Product> items = _dbContext.Product.AsNoTracking();

            return Mapper.Map(items);
        }

        /// <summary>
        /// Get a order by ID, including any associated reviews.
        /// </summary>
        /// <returns>The order</returns>
        public BusinessBears.Library.Training GetProductById(int id)
        {
            Product order = _dbContext.Product
                .AsNoTracking().First(r => r.ProductId == id);
            return Mapper.Map(order);
        }

      

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
