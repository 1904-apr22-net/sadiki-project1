﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessBears.WebUI.Models
{
    public class SoldBearsViewModel
    {
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "Location ID")]
        public int ID { get; set; }

        [Required]
        public IEnumerable<SoldTrainingViewModel> SoldTraining { get; set; }
    }
}
