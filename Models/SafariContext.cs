using System;
using System.Collections.Generic;
using System.Data.Entity; // Context
using System.Linq;
using System.Web;

namespace Tut9Advanced.Models
{
    public class SafariContext : DbContext
    {
        public SafariContext() : base ("Safari") { }

        public DbSet<GameDrive> gameDrives { get; set; }
        public DbSet<Vehicle> vehicles { get; set; }
        public DbSet<Driver> drivers { get; set; }
        public DbSet<Code10DriverPerfomanceViewModel> code10Drivers { get; set; }
    }
}