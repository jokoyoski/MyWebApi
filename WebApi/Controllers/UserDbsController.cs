using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApi.DataAccess;
using WebApi.Models;

namespace WebApi.Controllers
{
    public class UserDbsController : Controller
    {
        private EFDbContext db = new EFDbContext();

        // GET: UserDbs
        public ActionResult Index()
        {
            return View(db.UserDbs.ToList());
        }

        // GET: UserDbs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDb userDb = db.UserDbs.Find(id);
            if (userDb == null)
            {
                return HttpNotFound();
            }
            return View(userDb);
        }

        // GET: UserDbs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UserDbs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,FirstName,LastName,Email,Password")] UserDb userDb)
        {
            if (ModelState.IsValid)
            {
                db.UserDbs.Add(userDb);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(userDb);
        }

        // GET: UserDbs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDb userDb = db.UserDbs.Find(id);
            if (userDb == null)
            {
                return HttpNotFound();
            }
            return View(userDb);
        }

        // POST: UserDbs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,FirstName,LastName,Email,Password")] UserDb userDb)
        {
            if (ModelState.IsValid)
            {
                db.Entry(userDb).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(userDb);
        }

        // GET: UserDbs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            UserDb userDb = db.UserDbs.Find(id);
            if (userDb == null)
            {
                return HttpNotFound();
            }
            return View(userDb);
        }

        // POST: UserDbs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            UserDb userDb = db.UserDbs.Find(id);
            db.UserDbs.Remove(userDb);
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
