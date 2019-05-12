using System;
using System.Collections.Generic;

namespace BusinessBears.Library.Interfaces
{
    /// <summary>
    /// A repository managing data access for order objects and their review members.
    /// </summary>
    public interface IOrderRepository : IDisposable
    {
        /// <summary>
        /// Get all order with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of order</returns>
        IEnumerable<Order> GetOrders();

        /// <summary>
        /// Get a order by ID, including any associated reviews.
        /// </summary>
        /// <returns>The order</returns>
       // Order GetOrderById(int id);

        /// <summary>
        /// Add a order, including any associated reviews.
        /// </summary>
        /// <param name="Order">The order</param>
        void AddOrder(Order Order);

        /// <summary>
        /// Delete a order by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="ordertId">The ID of the Order</param>
       // void DeleteOrder(int orderId);

        /// <summary>
        /// Update a Order as well as its reviews.
        /// </summary>
        /// <param name="Order">The Order with changed values</param>
        //void UpdateOrder(Order order);

        ///// <summary>
        ///// Get a review.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        //Review GetReviewById(int reviewId);

        ///// <summary>
        ///// Add a review and optionally associate it with a Order.
        ///// </summary>
        ///// <param name="review">The review</param>
        ///// <param name="Order">The order (or null if none)</param>
        //void AddReview(Review review, Order order = null);

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
        ///// Get the ID of the order associated to the review with the given ID.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        ///// <returns>The ID of the order</returns>
        //int OrderIdFromReviewId(int reviewId);

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();
    }
}
