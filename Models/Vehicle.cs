using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tut9Advanced.Models
{
    public class Vehicle
    {
       [Key]
       public int VehicleId { get; set; } 
       public string VehicleType { get; set; }

        [Required]
        [Range(1, 8, ErrorMessage = "Max passengers must be between 1 and 8.")]
        public int MaxPassengers { get; set; }

        public int CurrentFuelLevel { get; set;  }

        public decimal RatePerPerson { get; set; }

       // public int DriverPoints { get; set; }
        //public decimal DriverCash { get; set; }
    }
}