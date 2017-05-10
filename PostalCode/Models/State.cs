using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace PostalCode.Models
{
    public class State
    {
        public int Id { get; set; }

        [Display(Name ="State Name")]
        public string Name { get; set; }

        [Display(Name ="Number of People in State")]
        public int NumOfPeople { get; set; }
    }
}