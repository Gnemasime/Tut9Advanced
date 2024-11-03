using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tut9Advanced.Models
{
    public class Code10DriverPerfomanceViewModel
    {
        [Key]
        public int DriverPerfomanceVM { get; set; }
        public string DriverName { get; set; }
        public string LicenseType { get; set; }
        public int PointsEarned { get; set; }
        public decimal TotalDriverEarning { get; set; }
        public int AverageRating { get; set; }
    }
}