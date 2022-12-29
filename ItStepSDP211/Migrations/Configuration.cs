namespace ItStepSDP211.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<ItStepSDP211.Models.MovieContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(ItStepSDP211.Models.MovieContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Movies.Add(new Models.Movie { Name = "Аватар 2", Author = "Джеймс Камерон", CreatedBy = "Universal Pictures", Date = DateTime.ParseExact("2022-12-10", "yyyy-mm-dd", null) });
            context.Movies.Add(new Models.Movie { Name = "Терминатор", Author = "Дмитрий Егорович", CreatedBy = "20 век фокс", Date = DateTime.ParseExact("2022-11-10", "yyyy-mm-dd", null) });
            context.Movies.Add(new Models.Movie { Name = "Мстители", Author = "Джон Сноу", CreatedBy = "Марвел", Date = DateTime.ParseExact("2022-02-10", "yyyy-mm-dd", null) });
            context.Movies.Add(new Models.Movie { Name = "Большой куш", Author = "Ерлан Калиакпаров", CreatedBy = "Universal Pictures", Date = DateTime.ParseExact("2022-01-10", "yyyy-mm-dd", null) });
            context.Movies.Add(new Models.Movie { Name = "Губка боб", Author = "Зедрик Африка", CreatedBy = "Universal Pictures", Date = DateTime.ParseExact("2022-09-10", "yyyy-mm-dd", null) });


            base.Seed(context);

        }
    }
}
