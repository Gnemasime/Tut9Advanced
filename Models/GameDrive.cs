using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Tut9Advanced.Models
{
    public class GameDrive
    {
        [Key]
        public int GameDriveId { get; set; }
        public int VehicleId { get; set; }
        public int DriverId { get; set; }
        public DateTime DriverDate { get; set; }
        public int NumOfPassengers { get; set; }
        public decimal Totaldriveearnings { get; set; }
        public bool IsCompleted { get; set; }

        public int Rating { get; set; }

        //Foreign Key
        public virtual Vehicle Vehicle { get; set; }
        public virtual Driver Driver { get; set; }

       // Updating Driver Points
        public void AddDriverPoints()
        {
            SafariContext db = new SafariContext();
            Driver driver = (from c in db.drivers
                             where c.DriverId == DriverId
                             select c).FirstOrDefault();

            driver.DriverPoints += 100;
            db.SaveChanges();
        }

        //Method to pull points
        public int PullDriverPoints()
        {
            SafariContext db = new SafariContext();
            var points = (from c in db.drivers
                          where c.DriverId == DriverId
                          select c.DriverPoints).FirstOrDefault();
            return points;
        }

        //Method for calculating driver cash
        // 350 = 1000, 2000 = 700, 5000 = 1750
        public decimal CalcDriverCash()
        {
            if(PullDriverPoints() >= 1000)
            {
                return (PullDriverPoints() / 1000) * 350;
            }
            else
            {
                return 0;
            }
        }

        //method to calculate total driver earnings
        public decimal CalcTotalDriveEarnings()
        {
            SafariContext db = new SafariContext();
            var rate = (from b in db.vehicles
                        where b.VehicleId == VehicleId
                        select b.RatePerPerson).FirstOrDefault();

            return rate * NumOfPassengers;
        }

        //Method for driver penalty
        public decimal ApplyDriverPenalty()
        {
            if(Rating > 1 && Rating < 3)
            {
                return CalcDriverCash() - (CalcDriverCash() * (3 / 100.0m)); // 100 - (100 * 3/100.0)
            }
            else
            {
                return 0;
            }
        }
         //Apply driver rewards

        public int ApplyDriverReward()
        {
            if(Rating > 4 && Rating < 5)
            {
                return PullDriverPoints() + 50;
            }
            else
            {
                return PullDriverPoints();
            }
        }
    }
}