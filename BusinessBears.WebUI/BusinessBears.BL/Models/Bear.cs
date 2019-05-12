using BusinessBears.Library.Abstracts;
using System;
using System.Collections.Generic;

namespace BusinessBears.Library
{


    /// <summary>
    /// The Bear Class is the primary product subclass. Contains a Hashset used to 
    /// hold additional products sold alongside the bear
    /// </summary>
    public class Bear : Product
    {
        public Bear()
        {
            this._name = "Bear";
        }

     

        protected readonly double _price = 199.99;
        

        public int ID { get; set; }
        public double Price { get; set; }

        public override double getPrice()
        {
            return this._price;
        }


    }
}

  
