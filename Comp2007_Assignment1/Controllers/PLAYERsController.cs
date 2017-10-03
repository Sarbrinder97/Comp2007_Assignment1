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
    public class PLAYERsController : Controller
    {
        private TeamsModel db = new TeamsModel();

        // GET: PLAYERs
        public ActionResult Index()
        {
            var pLAYERS = db.PLAYERS.Include(p => p.TEAM);

            return View(pLAYERS.ToList());
        }

        // GET: PLAYERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAYER pLAYER = db.PLAYERS.Find(id);
            if (pLAYER == null)
            {
                return HttpNotFound();
            }
            return View(pLAYER);
        }

        // GET: PLAYERs/Create
        public ActionResult Create()
        {
            ViewBag.TEAM_ID = new SelectList(db.TEAMS, "TEAM_ID", "TEAM_NAME");
            return View();
        }

        // POST: PLAYERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "JERSEY_NUMBER,PLAYER_NAME,POINTS_PER_GAME,REBOUNDS_PER_GAME,ASSISTS_PER_GAME,TEAM_ID")] PLAYER pLAYER)
        {
            if (ModelState.IsValid)
            {
                db.PLAYERS.Add(pLAYER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.TEAM_ID = new SelectList(db.TEAMS, "TEAM_ID", "TEAM_NAME", pLAYER.TEAM_ID);
            return View(pLAYER);
        }

        // GET: PLAYERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAYER pLAYER = db.PLAYERS.Find(id);
            if (pLAYER == null)
            {
                return HttpNotFound();
            }
            ViewBag.TEAM_ID = new SelectList(db.TEAMS, "TEAM_ID", "TEAM_NAME", pLAYER.TEAM_ID);
            return View(pLAYER);
        }

        // POST: PLAYERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JERSEY_NUMBER,PLAYER_NAME,POINTS_PER_GAME,REBOUNDS_PER_GAME,ASSISTS_PER_GAME,TEAM_ID")] PLAYER pLAYER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(pLAYER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.TEAM_ID = new SelectList(db.TEAMS, "TEAM_ID", "TEAM_NAME", pLAYER.TEAM_ID);
            return View(pLAYER);
        }

        // GET: PLAYERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PLAYER pLAYER = db.PLAYERS.Find(id);
            if (pLAYER == null)
            {
                return HttpNotFound();
            }
            return View(pLAYER);
        }

        // POST: PLAYERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            PLAYER pLAYER = db.PLAYERS.Find(id);
            db.PLAYERS.Remove(pLAYER);
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
