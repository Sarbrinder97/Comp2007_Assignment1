using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Comp2007_Assignment1.Models;

namespace Comp2007_Assignment1.Controllers
{
    public class TEAMsController : Controller
    {
        private TeamsModel db = new TeamsModel();

        // GET: TEAMs
        public ActionResult Index()
        {
            var teams = from t in db.TEAMS
                        orderby t.TEAM_NAME ascending
                        select t;
            ViewBag.Message = "Please select a team";
            return View(teams);
        }

        // GET: TEAMs/Details/5
        //public ActionResult Details(int? id)
        //{
        //    if (id == null)
        //    {
        //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    }
        //    TEAM tEAM = db.TEAMS.Find(id);
        //    if (tEAM == null)
        //    {
        //        return HttpNotFound();
        //    }
        //    return View(tEAM);
        //}

        public ActionResult Browse(string team)
        {
            var selectedTeam = db.TEAMS.Include("PLAYERS")
                                .Single(t => t.TEAM_NAME == team);
            return View(selectedTeam);
        }
        // GET: TEAMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: TEAMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TEAM_ID,TEAM_NAME,TEAM_CITY,TEAM_SPONSER")] TEAM tEAM)
        {
            if (ModelState.IsValid)
            {
                db.TEAMS.Add(tEAM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tEAM);
        }

        // GET: TEAMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMS.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // POST: TEAMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TEAM_ID,TEAM_NAME,TEAM_CITY,TEAM_SPONSER")] TEAM tEAM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tEAM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tEAM);
        }

        // GET: TEAMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TEAM tEAM = db.TEAMS.Find(id);
            if (tEAM == null)
            {
                return HttpNotFound();
            }
            return View(tEAM);
        }

        // POST: TEAMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TEAM tEAM = db.TEAMS.Find(id);
            db.TEAMS.Remove(tEAM);
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
