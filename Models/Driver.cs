using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tut9Advanced.Models
{
    public class Driver
    {
        [Key]
        public int DriverId { get; set; }
        public string DriverName { get; set; }
        public string LicenseType { get; set; }
        public int AssignedVehicleId { get; set; }
       // public virtual Vehicle Vehicle { get; set; }

        public int DriverPoints { get; set; }
        public decimal DriverCash { get; set; }
    }
}