using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItStepSDP211.Controllers
{
    public class HomeController : Controller
    {
        [HttpPut]
        public ActionResult Index()
        {
            return View();
        }
        private string Index2()
        {
            return "2";
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}