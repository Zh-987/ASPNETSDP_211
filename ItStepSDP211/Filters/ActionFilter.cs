using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;

namespace ItStepSDP211.Filters
{
    public class ActionFilter : FilterAttribute, IActionFilter
    {
        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            /*if(filterContext.HttpContext.Request.Browser.Browser == "Chrome")
            {
                filterContext.Result = new HttpNotFoundResult();
            }*/

            filterContext.HttpContext.Response.Write("Current User:" + filterContext.HttpContext.User.Identity.Name);

        }
        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            filterContext.HttpContext.Response.Write("Time of current request:"+filterContext.HttpContext.Timestamp);
            /* filterContext.HttpContext.Response.Write("Action done");*/
        }

    }
}