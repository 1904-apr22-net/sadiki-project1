using System;
using System.Collections.Generic;

namespace BusinessBears.Library.Interfaces
{
    /// <summary>
    /// A repository managing data access for customer objects and their review members.
    /// </summary>
    public interface ICustomerRepository : IDisposable
    {
        /// <summary>
        /// Get all customer with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of customer</returns>
        IEnumerable<Customer> GetCustomers(string search = null);

        /// <summary>
        /// Get a customer by ID, including any associated reviews.
        /// </summary>
        /// <returns>The customer</returns>
        Customer GetCustomerById(int id);

        /// <summary>
        /// Add a customer, including any associated reviews.
        /// </summary>
        /// <param name="Customer">The customer</param>
        void AddCustomer(Customer Customer);

        /// <summary>
        /// Delete a customer by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="customertId">The ID of the Customer</param>
        void DeleteCustomer(int customerId);

        /// <summary>
        /// Update a Customer as well as its reviews.
        /// </summary>
        /// <param name="Customer">The Customer with changed values</param>
        void UpdateCustomer(Customer customer);

        ///// <summary>
        ///// Get a review.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        //Review GetReviewById(int reviewId);

        ///// <summary>
        ///// Add a review and optionally associate it with a Customer.
        ///// </summary>
        ///// <param name="review">The review</param>
        ///// <param name="Customer">The customer (or null if none)</param>
        //void AddReview(Review review, Customer customer = null);

        ///// <summary>
        ///// Delete a review by ID.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        //void DeleteReview(int reviewId);

        ///// <summary>
        ///// Update a review.
        ///// </summary>
        ///// <param name="review">The review with changed values</param>
        //void UpdateReview(Review review);

        ///// <summary>
        ///// Get the ID of the customer associated to the review with the given ID.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        ///// <returns>The ID of the customer</returns>
        //int CustomerIdFromReviewId(int reviewId);

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();
    }
}
