using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ItStepSDP211.Models;
using Ninject.Modules;

namespace ItStepSDP211.Util
{
    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            Bind<IRepository>().To<MovieRepository>();
        }
    }
}