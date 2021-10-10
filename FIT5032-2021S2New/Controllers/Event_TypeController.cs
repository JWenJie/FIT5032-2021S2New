using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using FIT5032_2021S2New.Models;

namespace FIT5032_2021S2New.Controllers
{
    public class Event_TypeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Event_Type
        public ActionResult Index()
        {
            return View(db.Event_Types.ToList());
        }

        // GET: Event_Type/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Type event_Type = db.Event_Types.Find(id);
            if (event_Type == null)
            {
                return HttpNotFound();
            }
            return View(event_Type);
        }

        // GET: Event_Type/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Event_Type/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Event_type_id,Event_name,Prize,Description")] Event_Type event_Type)
        {
            if (ModelState.IsValid)
            {
                db.Event_Types.Add(event_Type);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(event_Type);
        }

        // GET: Event_Type/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Type event_Type = db.Event_Types.Find(id);
            if (event_Type == null)
            {
                return HttpNotFound();
            }
            return View(event_Type);
        }

        // POST: Event_Type/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Event_type_id,Event_name,Prize,Description")] Event_Type event_Type)
        {
            if (ModelState.IsValid)
            {
                db.Entry(event_Type).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(event_Type);
        }

        // GET: Event_Type/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Event_Type event_Type = db.Event_Types.Find(id);
            if (event_Type == null)
            {
                return HttpNotFound();
            }
            return View(event_Type);
        }

        // POST: Event_Type/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Event_Type event_Type = db.Event_Types.Find(id);
            db.Event_Types.Remove(event_Type);
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
