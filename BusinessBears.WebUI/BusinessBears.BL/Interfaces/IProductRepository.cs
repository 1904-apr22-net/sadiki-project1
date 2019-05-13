using System;
using System.Collections.Generic;

namespace BusinessBears.Library.Interfaces
{
    /// <summary>
    /// A repository managing data access for location objects and their review members.
    /// </summary>
    public interface IProductRepository : IDisposable
    {
        /// <summary>
        /// Get all location with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of location</returns>
        IEnumerable<Training> GetProducts();

        /// <summary>
        /// Get a location by ID, including any associated reviews.
        /// </summary>
        /// <returns>The location</returns>
        Training GetProductById(int id);

        /// <summary>
        /// Persist changes to the data source.
        /// </summary>
        void Save();
    }
}
