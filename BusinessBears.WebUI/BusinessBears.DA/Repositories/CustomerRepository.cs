using BusinessBears.DA;
using BusinessBears.DA.Entities;
using BusinessBears.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomerReviews.DataAccess.Repositories
{
    /// <summary>
    /// A repository managing data access for customer objects and their review members,
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class CustomerRepository : ICustomerRepository
    {
        private readonly BBearContext  _dbContext;

        private readonly ILogger<CustomerRepository> _logger;

        /// <summary>
        /// Initializes a new customer repository given a suitable customer data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public CustomerRepository(BBearContext dbContext, ILogger<CustomerRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all customers with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of customers</returns>
        public IEnumerable<BusinessBears.Library.Customer> GetCustomers(string search = null)
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Customer> items = _dbContext.Customer
                .AsNoTracking();
            if (search != null)
            {
                items = items.Where(r => r.FirstName.Contains(search) || r.LastName.Contains(search));
            }
            return Mapper.Map(items);
        }

        /// <summary>
        /// Get a customer by ID, including any associated reviews.
        /// </summary>
        /// <returns>The customer</returns>
        public BusinessBears.Library.Customer GetCustomerById(int id)
        {
            Customer customer = _dbContext.Customer
                .AsNoTracking().First(r => r.CustomerId == id);
            return Mapper.Map(customer);
        }

        /// <summary>
        /// Add a customer, including any associated reviews.
        /// </summary>
        /// <param name="customer">The customer</param>
        public void AddCustomer(BusinessBears.Library.Customer Customer)
        {
            if (Customer.Id != 0)
            {
                _logger.LogWarning("Customer to be added has an ID ({customerId}) already: ignoring.", Customer.Id);
            }

            _logger.LogInformation($"Adding customer");

            Customer entity = Mapper.Map(Customer);
            entity.CustomerId = 0;
            _dbContext.Add(entity);
        }

        /// <summary>
        /// Delete a customer by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="customerId">The ID of the customer</param>
        public void DeleteCustomer(int customerId)
        {
            _logger.LogInformation("Deleting customer with ID {customerId}", customerId);
            Customer entity = _dbContext.Customer.Find(customerId);
            _dbContext.Remove(entity);
        }

        /// <summary>
        /// Update a customer as well as its reviews.
        /// </summary>
        /// <param name="customer">The customer with changed values</param>
        public void UpdateCustomer(BusinessBears.Library.Customer customer)
        {
            _logger.LogInformation("Updating customer with ID {customerId}", customer.Id);

            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            Customer currentEntity = _dbContext.Customer.Find(customer.Id);
            Customer newEntity = Mapper.Map(customer);

            _dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
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
