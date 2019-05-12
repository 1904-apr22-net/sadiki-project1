using BusinessBears.Library.Abstracts;
using System;
using System.Collections.Generic;

namespace BusinessBears.Library
{

    /// <summary>
    /// Training is the secondary product class, designed to be attached to a Bear class to
    /// increase the price or slotted into an InventoryItem to track stocking.
    /// </summary>

    public class Training : Product
    {
        double _price;


        public int ID { get; set; }

        public double Price { get => _price; set => _price = value; }

        public override double getPrice()
        {
            return this._price;
        }

    }
}

   