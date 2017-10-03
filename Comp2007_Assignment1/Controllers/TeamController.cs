using Comp2007_Assignment1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Comp2007_Assignment1.Controllers
{
    
    public class TeamController : Controller
    {
        TeamsModel db = new TeamsModel();
        // GET: Team
        public ActionResult Index()
        {
            var teams = from t in db.TEAMS
                        orderby t.TEAM_NAME ascending
                        select t;
            ViewBag.Message = "Please select a team";
            return View(teams);
        }
        // GET: TEAM/Browse
        public ActionResult Browse (string team)
        {
            var selectedTeam = db.TEAMS.Include("PLAYERS")
                                .Single(t => t.TEAM_NAME == team);
            return View(selectedTeam);
        }
    }
    
    

}