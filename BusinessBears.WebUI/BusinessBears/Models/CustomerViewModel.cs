using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BusinessBears.WebUI.Models
{
    public class CustomerViewModel
    {
        // the HTML/tag helpers like "DisplayNameFor"
        // will use this instead of the property's name
        [Display(Name = "ID")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Required]
        [Display(Name = "Last Name")]
        public string LastName { get; set; }

        //public IEnumerable<ReviewViewModel> Reviews { get; set; }

        [DisplayFormat(DataFormatString = "{0:#.##}")]
        public double? Score { get; set; }
    }
}
