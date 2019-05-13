using BusinessBears.Library.Abstracts;
using System;
using System.Collections.Generic;

namespace BusinessBears.Library
{
    /// <summary>
    /// A holding class used to integrate Product subclasses with Location.Inventory
    /// </summary>
    public class TrainingContainer
    {
        public int ID { get; set; }
        private Training product;
        public Training Product { get => product; set => product = value;
        }

        //public InventoryItem(Training p, int i)
        //{
        //    this.product = p;
        //    this._quantity = i;
        //}
    }
}
