using ItStepSDP211.Filters;
using ItStepSDP211.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace ItStepSDP211.Controllers
{
    public class AdminController : Controller
    {
        LogContext db = new LogContext();
            
        // GET: Admin
        public ActionResult Index()
        {
            return View(db.ExceptionDetails.ToList());
        }

        [ExceptionFilter]
        public ActionResult Test(int id)
        {
            if(id > 3)
            {
                int[] arr = new int[2];
                arr[4] = 3;
            }
            else if (id<3)
            {
                throw new Exception("id can not less than 3");
            }
            else
            {
                throw new Exception("Incorrect info");
            }

            return View();
        }

    }
}