﻿using System;
using System.Collections.Generic;
using System.Text;

namespace BusinessBears.Library
{
    /// <summary>
    /// A Customer object that records name, order history, last order time and default location
    /// </summary>
    public class Customer
    {
        public int Id { get; set; }
        private string _firstname;
        private string _lastname;

        public string FirstName { get => _firstname; set => _firstname = value; }
        public string LastName { get => _lastname; set => _lastname = value; }

        int? defLocation;
        DateTime? LastOrder;
        /// <summary>
        /// Takes in the current date and determines whether the difference between it and the
        /// time of the last order are at least two hours apart
        /// </summary>
        /// <param name="d">A DateTime object, ideally the current date/time</param>
        /// <returns>Returns bool. True if the input is at least two hours from the last order
        /// and false if otherwise.</returns>
        public bool OrderLimit(DateTime d)
        {
            DateTime d2 = LastOrder ?? new DateTime();
            if (d.Subtract(d2) < new TimeSpan(2,0,0))
            {
                return false;
            }
            else
            {
                return true;
            }
        }
     


        public Customer (int i, string fn, string ln, DateTime? dt, int? deflocation)
        {
            this.Id = i;
            this.FirstName = fn;
            this.LastName = ln;
            this.LastOrder = dt ?? new DateTime();
            this.defLocation = deflocation;

        }

        public Customer()
        {
        }
    }
}
