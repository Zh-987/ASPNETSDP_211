namespace ItStepSDP211.Migrations
{
    using ItStepSDP211.Models;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ItStepSDP211.Models.SoccerContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "ItStepSDP211.Models.SoccerContext";
        }

        protected override void Seed(ItStepSDP211.Models.SoccerContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            var menuItems = new List<MenuItem>
           {
               new MenuItem{ Id=1, Header="Main", Url="/Players/Index",Order = 1},
               new MenuItem{ Id=2, Header="Create Player", Url="/Players/Create",Order = 2},
               new MenuItem{ Id=3, Header="Create Team", Url="/Players/CreateTeam",Order = 3},
               new MenuItem{ Id=4, Header="Child 1", Url="#",Order = 1, ParentId = 2 },
               new MenuItem{ Id=5, Header="Child 2", Url="#",Order = 2, ParentId = 2 },
               new MenuItem{ Id=6, Header="Child 1", Url="#",Order = 1, ParentId = 4 },
               new MenuItem{ Id=7, Header="Child 2", Url="#",Order = 2, ParentId = 4 }
           };
            context.MenuItems.AddRange(menuItems);
            context.SaveChanges();
        }
    }
}
