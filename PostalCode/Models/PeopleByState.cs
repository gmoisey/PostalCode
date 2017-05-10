using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PostalCode.Models
{
    public class PeopleByState
    {
        [Display(Name ="First Name")]
        public string FirstName { get; set; }

        [Display(Name ="Last Name")]
        public string Lastname { get; set; }

        [Display(Name ="Zip Code")]
        public string ZipCode { get; set; }
    }
}