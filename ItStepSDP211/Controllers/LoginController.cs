using ItStepSDP211.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItStepSDP211.Controllers
{
    public class LoginController : Controller
    {
        MovieContext db = new MovieContext();
        // GET: Login
        [HttpGet]
        public ActionResult Index()
        {
            SelectList movies = new SelectList(db.Movies, "Author", "Name");
            ViewBag.Movies = movies;
            return View();
        }

        [HttpPost]
        public string Index(string[] countries)
        {
            string result = "";
            foreach (string c in countries)
            {
                result += c;
                result += ";";
            }
            return "Your choice: " + result;
        }

        public ActionResult TwoButtons()
        {
            return View();
        }

        [HttpPost]
        public ActionResult TwoButtons(string action)
        {
           if(action == "Add")
            {

            }
            else if ( action == "Delete")
            {

            }
            return View();
        }

    }
}