using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SAT.DATA.EF;

namespace SAT.UI.MVC.Controllers
{
    public class ScheduleClassStatusController : Controller
    {
        private SATEntities db = new SATEntities();

        // GET: ScheduleClassStatus
        public ActionResult Index()
        {
            return View(db.ScheduleClassStatuses.ToList());
        }

        // GET: ScheduleClassStatus/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleClassStatus scheduleClassStatus = db.ScheduleClassStatuses.Find(id);
            if (scheduleClassStatus == null)
            {
                return HttpNotFound();
            }
            return View(scheduleClassStatus);
        }

        // GET: ScheduleClassStatus/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScheduleClassStatus/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SCSID,SCSName")] ScheduleClassStatus scheduleClassStatus)
        {
            if (ModelState.IsValid)
            {
                db.ScheduleClassStatuses.Add(scheduleClassStatus);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(scheduleClassStatus);
        }

        // GET: ScheduleClassStatus/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleClassStatus scheduleClassStatus = db.ScheduleClassStatuses.Find(id);
            if (scheduleClassStatus == null)
            {
                return HttpNotFound();
            }
            return View(scheduleClassStatus);
        }

        // POST: ScheduleClassStatus/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SCSID,SCSName")] ScheduleClassStatus scheduleClassStatus)
        {
            if (ModelState.IsValid)
            {
                db.Entry(scheduleClassStatus).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(scheduleClassStatus);
        }

        // GET: ScheduleClassStatus/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            ScheduleClassStatus scheduleClassStatus = db.ScheduleClassStatuses.Find(id);
            if (scheduleClassStatus == null)
            {
                return HttpNotFound();
            }
            return View(scheduleClassStatus);
        }

        // POST: ScheduleClassStatus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            ScheduleClassStatus scheduleClassStatus = db.ScheduleClassStatuses.Find(id);
            db.ScheduleClassStatuses.Remove(scheduleClassStatus);
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
