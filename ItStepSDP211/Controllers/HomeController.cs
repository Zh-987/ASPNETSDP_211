using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItStepSDP211.Models;
using Microsoft.Ajax.Utilities;
using ItStepSDP211.Util;

namespace ItStepSDP211.Controllers
{
    public class HomeController : Controller
    {
        MovieContext db = new MovieContext();
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = db.Movies;
            ViewBag.Movies = movies;

            return View();
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            ViewBag.MovieId = id;

            return View();
        }
        [HttpPost]
        public string Buy(BuyTickets buyTickets)
        {
            buyTickets.Date = DateTime.Now;
            buyTickets.Price = 800;
            buyTickets.Email = "qwerty@qwerty";
            buyTickets.Person = "Jhon";

            db.Tickets.Add(buyTickets);

            db.SaveChanges();

            return "Thank you for purchasing our ticket " + buyTickets.Person +" ! ";
        }

        private DateTime detToday()
        {
            return DateTime.Now;
        }


        public string Square()
        {
            int a = Int32.Parse(Request.Params["a"]);
            int h = Int32.Parse(Request.Params["h"]);
            double s = a * h / 2.0;
            return "<h2> a = " + a + "h = "+ h +" Square =" + s +"</h2>" ;
        }

        public ActionResult GetHtml()
        {
            return new HtmlResult("Hello world !");
        }
    }
}