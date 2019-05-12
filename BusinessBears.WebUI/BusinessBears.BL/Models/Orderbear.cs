using BusinessBears.Library.Abstracts;
using System;
using System.Collections.Generic;

namespace BusinessBears.Library
{


    /// <summary>
    /// The Bear Class is the primary product subclass. Contains a Hashset used to 
    /// hold additional products sold alongside the bear
    /// </summary>
    public class OrderBear
    {
       

        public List<TrainingContainer> upgrades;

        public int ID { get; set; }
        public double Price { get; set; }
        public int OrderId { get; set; }

        /// <summary>
        /// Used to add Training objects to the bear. Used for order processing
        /// </summary>
        /// <param name="training">It takes a training object in order to add it to the upgrades Hashset</param>
        public void AddTraining(TrainingContainer training)
        {
            upgrades.Add(training);
        }
        /// <summary>
        /// Bear.getPrice() returns the total cost of the bear, accounting for any training the bear will receive as part of the purchase
        /// </summary>
        /// <returns></returns>
        public double getTotalPrice()
        {
            double d = this.Price;
            foreach (TrainingContainer item in upgrades)
            {
                d += item.Product.getPrice();
            }
            return d;
        }

    }
        }

  
