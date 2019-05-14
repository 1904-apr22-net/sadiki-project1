using System;
using System.Collections.Generic;

namespace BusinessBears.Library.Interfaces
{
    /// <summary>
    /// A repository managing data access for location objects and their review members.
    /// </summary>
    public interface ILocationRepository : IDisposable
    {
        /// <summary>
        /// Get all location with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of location</returns>
        IEnumerable<Location> GetLocations();

        /// <summary>
        /// Get a location by ID, including any associated reviews.
        /// </summary>
        /// <returns>The location</returns>
        Location GetLocationById(int id);

        /// <summary>
        /// Add a location, including any associated reviews.
        /// </summary>
        /// <param name="Location">The location</param>
        //void AddLocation(Location Location);

        /// <summary>
        /// Delete a location by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="locationtId">The ID of the Location</param>
        //void DeleteLocation(int locationId);

        /// <summary>
        /// Update a Location.
        /// </summary>
        /// <param name = "Location" > The Location with changed values</param>

            void UpdateLocation(Location location);

        ///// <summary>
        ///// Get a review.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        //Review GetReviewById(int reviewId);

        ///// <summary>
        ///// Add a review and optionally associate it with a Location.
        ///// </summary>
        ///// <param name="review">The review</param>
        ///// <param name="Location">The location (or null if none)</param>
        //void AddReview(Review review, Location location = null);

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
        ///// Get the ID of the location associated to the review with the given ID.
        ///// </summary>
        ///// <param name="reviewId">The ID of the review</param>
        ///// <returns>The ID of the location</returns>
        //int LocationIdFromReviewId(int reviewId);

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();
    }
}
