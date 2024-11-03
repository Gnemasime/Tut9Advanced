using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Tut9Advanced.Models;

namespace Tut9Advanced.Controllers
{
    public class Code10DriverPerfomanceViewModelController : Controller
    {
        private SafariContext db = new SafariContext();

        // GET: Code10DriverPerfomanceViewModel
        public ActionResult Index()
        {
            //  return View(db.code10Drivers.ToList());
            List<Code10DriverPerfomanceViewModel> code10Drivers = new List<Code10DriverPerfomanceViewModel>();
            var drivers = (from dr in db.drivers
                           join gm in db.gameDrives on dr.DriverId equals gm.DriverId
                           where dr.LicenseType == "Code10"
                           //join vh in db.vehicles on gm.VehicleId equals vh.VehicleId
                           select new { dr.DriverName, dr.LicenseType, dr.DriverPoints, gm.Totaldriveearnings, gm.Rating }).ToList();

           
            foreach( var code in drivers )
            {
                Code10DriverPerfomanceViewModel drive = new Code10DriverPerfomanceViewModel();
                drive.DriverName = code.DriverName;
                drive.LicenseType = code.LicenseType;
                drive.PointsEarned = code.DriverPoints;
                drive.TotalDriverEarning = code.Totaldriveearnings;
                drive.AverageRating = code.Rating;
                //Calc  total earning

                code10Drivers.Add(drive);
            }

            return View(code10Drivers);
        }

        // GET: Code10DriverPerfomanceViewModel/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code10DriverPerfomanceViewModel code10DriverPerfomanceViewModel = db.code10Drivers.Find(id);
            if (code10DriverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(code10DriverPerfomanceViewModel);
        }

        // GET: Code10DriverPerfomanceViewModel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Code10DriverPerfomanceViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "DriverPerfomanceVM,DriverName,LicenseType,PointsEarned,TotalDriverEarning,AverageRating")] Code10DriverPerfomanceViewModel code10DriverPerfomanceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.code10Drivers.Add(code10DriverPerfomanceViewModel);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(code10DriverPerfomanceViewModel);
        }

        // GET: Code10DriverPerfomanceViewModel/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code10DriverPerfomanceViewModel code10DriverPerfomanceViewModel = db.code10Drivers.Find(id);
            if (code10DriverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(code10DriverPerfomanceViewModel);
        }

        // POST: Code10DriverPerfomanceViewModel/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "DriverPerfomanceVM,DriverName,LicenseType,PointsEarned,TotalDriverEarning,AverageRating")] Code10DriverPerfomanceViewModel code10DriverPerfomanceViewModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(code10DriverPerfomanceViewModel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(code10DriverPerfomanceViewModel);
        }

        // GET: Code10DriverPerfomanceViewModel/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Code10DriverPerfomanceViewModel code10DriverPerfomanceViewModel = db.code10Drivers.Find(id);
            if (code10DriverPerfomanceViewModel == null)
            {
                return HttpNotFound();
            }
            return View(code10DriverPerfomanceViewModel);
        }

        // POST: Code10DriverPerfomanceViewModel/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Code10DriverPerfomanceViewModel code10DriverPerfomanceViewModel = db.code10Drivers.Find(id);
            db.code10Drivers.Remove(code10DriverPerfomanceViewModel);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
