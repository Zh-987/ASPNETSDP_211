using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItStepSDP211.Filters
{
    public class ExceptionFilter: FilterAttribute, IExceptionFilter
    {
       public void OnException(ExceptionContext filterContext)
        {
            if(!filterContext.ExceptionHandled && filterContext.Exception is IndexOutOfRangeException)
            {
                filterContext.Result = new RedirectResult("~/Shared/Error");
                filterContext.ExceptionHandled = true;
            }
        }
    }
}