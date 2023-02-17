using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Integration.Mvc;
using ItStepSDP211.Models;

namespace ItStepSDP211.Util
{
    public class AutofacConfig
    {
        public static void ConfigureContainer() {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<MovieRepository>().As<IRepository>().WithProperty("Context", new MovieContext());
                //.WithParameters(new List<Parameter> { new NamedParameter("context", new MovieContext()), new NamedParameter("connectionString", "localhost") } );

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}