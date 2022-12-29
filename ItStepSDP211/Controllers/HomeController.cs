using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItStepSDP211.Models;

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
      
    }
}