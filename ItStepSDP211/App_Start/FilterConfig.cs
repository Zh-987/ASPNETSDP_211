using ItStepSDP211.Filters;
using System.Web;
using System.Web.Mvc;
using System.Web.WebSockets;

namespace ItStepSDP211
{
    public class FilterConfig
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new ExceptionFilter());
            filters.Add(new CacheAttribute());
        }
    }
}
