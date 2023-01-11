using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ItStepSDP211.Models;
using Microsoft.Ajax.Utilities;
using ItStepSDP211.Util;
using System.IO;
using System.Threading.Tasks;
using System.Data.Entity;

namespace ItStepSDP211.Controllers
{
    public class HomeController : Controller
    {
        MovieContext db = new MovieContext();

        //синхронный метод
        public ActionResult Index()
        {
            IEnumerable<Movie> movies = db.Movies;
            ViewBag.Movies = movies;
            ViewBag.Message = "This is Partial View !";
            Session["name"] = null; //"Tom Hardi";

            return View(db.Movies);
        }

        //асинхронный метод

        public async Task<ActionResult> MovieList()
        {
            IEnumerable<Movie> movies = await db.Movies.ToListAsync();
            ViewBag.Movies = movies;

            return View("Index");
        }

        public string getSessionName()
        {
            var val = Session["name"];
            return val.ToString();
        }


        public ViewResult SomeMthd()
        {
            ViewData["Head"] = "Hi Itstep !";
            ViewBag.Head1 = "Hi SDP-211 !";

            return View("Index");
        }

        public RedirectResult SwipeLink()
        {
            /*  return Redirect("/Home/Index"); Временная переадресация*/
            return RedirectPermanent("/Home/Index"); /*Постоянная переадресация*/

        }

        public RedirectToRouteResult SwipeLinkV2()
        {
            /* return RedirectToRoute(new { controller = "Home", action = "Index" });*/
            return RedirectToActionPermanent("Buy", "Home", new { id = 2 });
        }

        /*Файл через путь*/
        public FileResult GetFile()
        {
            string file_path = @"C:\Users\assai\source\repos\ASPNETSDP_211\ItStepSDP211\Files\10__CT.pdf";/*Server.MapPath("~/Files/10__CT.pdf");*/
            string file_type = "application/pdf";
            string file_name = "10__CT.pdf";
            return File(file_path, file_type, file_name);
        }
        /* Файл через байты*/
        public FileResult GetBytes()
        {
            string file_path = Server.MapPath("~/Files/10__CT.pdf");
            byte[] mas = System.IO.File.ReadAllBytes(file_path);
            string file_type = "application/pdf";
            string file_name = "10__CT.pdf";
            return File(mas, file_type, file_name);
        }
        /*Файлы через поток*/
        public FileResult GetStreams()
        {
            string file_path = Server.MapPath("~/Files/10__CT.pdf");
            FileStream fs = new FileStream(file_path, FileMode.Open);
            string file_type = "application/pdf";
            string file_name = "10__CT.pdf";
            return File(fs, file_type, file_name);
        }

        public string GetContext()
        {
            HttpContext.Response.Write("<h1>Welcome to HttpContext</h1>");

            string browser = HttpContext.Request.Browser.Browser;
            string user_agent = HttpContext.Request.UserAgent;
            string url = HttpContext.Request.RawUrl;
            string ip = HttpContext.Request.UserHostAddress;
            string referrer = HttpContext.Request.UrlReferrer == null ? "" : HttpContext.Request.UrlReferrer.AbsoluteUri;

            return "<p> Browser: " + browser + "</p> <p>User-Agent: " + user_agent + "</p><p>Url запрос: " + url + "</p> <p> Реферрер: " + referrer + "</p><p>IP: " + ip + "</p>";
        }

        public void ContextReponse()
        {
            HttpContext.Response.Write("<h1>Welcome to HttpContext</h1>");
        }

        public string isUser()
        {
            bool isAdmin = HttpContext.User.IsInRole("admin");
            bool isAuth = HttpContext.User.Identity.IsAuthenticated;
            string login = HttpContext.User.Identity.Name;

            return login;
        }

        public string Cookies()
        {
            HttpContext.Response.Cookies["id"].Value = "az-01w"; 
            string id = HttpContext.Request.Cookies["id"].Value;

            return id;
        }



        public ActionResult Check(int age)
        {
            if (age < 21)
            {
                /*return new HttpStatusCodeResult(404);*/
                /*return HttpNotFound();*/
                return new HttpUnauthorizedResult();
            }
            return View(); 
        }

        [HttpGet]
        public ActionResult Buy(int id)
        {
            if (id > 3)
            {
                return Redirect("/Home/Index");
            }

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

        public ActionResult GetImg()
        {
            string path = "../Images/unnamed.jpg";

            return new ImageResult(path);
        }

        public ActionResult Partial()
        {
            

            return PartialView();
        }



    }
}