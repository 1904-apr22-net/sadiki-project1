using BusinessBears.DA;
using BusinessBears.DA.Entities;
using BusinessBears.Library.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LocationReviews.DataAccess.Repositories
{
    /// <summary>
    /// A repository managing data access for location objects and their review members,
    /// using Entity Framework.
    /// </summary>
    /// <remarks>
    /// This class ought to have better exception handling and logging.
    /// </remarks>
    public class LocationRepository : ILocationRepository
    {
        private readonly BBearContext  _dbContext;

        private readonly ILogger<LocationRepository> _logger;

        /// <summary>
        /// Initializes a new cc repository given a suitable location data source.
        /// </summary>
        /// <param name="dbContext">The data source</param>
        /// <param name="logger">The logger</param>
        public LocationRepository(BBearContext dbContext, ILogger<LocationRepository> logger)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <summary>
        /// Get all locations with deferred execution, including any associated reviews.
        /// </summary>
        /// <returns>The collection of locations</returns>
        public IEnumerable<BusinessBears.Library.Location> GetLocations(string search = null)
        {
            // disable unnecessary tracking for performance benefit
            IQueryable<Location> items = _dbContext.Location.Include(x => x.Inventory).ThenInclude(x => x.Product)
                .AsNoTracking();
            
            return Mapper.Map(items);
        }

        /// <summary>
        /// Get a location by ID, including any associated reviews.
        /// </summary>
        /// <returns>The location</returns>
        public BusinessBears.Library.Location GetLocationById(int id)
        {
            Location location = _dbContext.Location.Include(x => x.Inventory).ThenInclude(x => x.Product)
                .AsNoTracking().First(r => r.LocationId == id);
            return Mapper.Map(location);
        }

        /// <summary>
        /// Add a location, including any associated reviews.
        /// </summary>
        /// <param name="location">The location</param>
        //public void AddLocation(BusinessBears.Library.Location location)
        //{
        //    if (location.Id != 0)
        //    {
        //        _logger.LogWarning("Location to be added has an ID ({locationId}) already: ignoring.", location.Id);
        //    }

        //    _logger.LogInformation($"Adding location");

        //    Location entity = Mapper.Map(location);
        //    entity.LocationId = 0;
        //    _dbContext.Add(entity);
        //}

        /// <summary>
        /// Delete a location by ID. Any reviews associated to it will also be deleted.
        /// </summary>
        /// <param name="locationId">The ID of the location</param>
        //public void DeleteLocation(int locationId)
        //{
        //    _logger.LogInformation("Deleting location with ID {locationId}", locationId);
        //    Location entity = _dbContext.Location.Find(locationId);
        //    _dbContext.Remove(entity);
        //}

        /// <summary>
        /// Update a location as well as its reviews.
        /// </summary>
        /// <param name="location">The location with changed values</param>
        public void UpdateLocation(BusinessBears.Library.Location location)
        {
            _logger.LogInformation("Updating location with ID {locationId}", location.ID);

            // calling Update would mark every property as Modified.
            // this way will only mark the changed properties as Modified.
            //Location currentEntity = _dbContext.Location.Include(x => x.Inventory).ThenInclude(y => y.Product).First(x => x.LocationId == location.ID);
            Location newEntity = Mapper.Map(location);

            _dbContext.Location.Update(newEntity);

            //_dbContext.Entry(currentEntity).CurrentValues.SetValues(newEntity);
            //foreach (var item in newEntity.Inventory)
            //{
            //    var q = _dbContext.Entry(currentEntity.Inventory.First(x => x.InventoryId == item.InventoryId));
            //    _dbContext.Entry(currentEntity.Inventory.First(x => x.InventoryId == item.InventoryId)).CurrentValues.SetValues(item);
            //}
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
