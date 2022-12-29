using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Web;

namespace ItStepSDP211.Models
{
    public class MoviesDbInitializer : DropCreateDatabaseAlways<MovieContext>
    {

        protected override void Seed(MovieContext db)
        {
            db.Movies.Add(new Movie { Name = "Аватар 2", Author ="Джеймс Камерон", CreatedBy="Universal Pictures", Date = DateTime.ParseExact("2022-12-10", "yyyy-mm-dd", null)});
            db.Movies.Add(new Movie { Name = "Терминатор", Author = "Дмитрий Егорович", CreatedBy = "20 век фокс", Date = DateTime.ParseExact("2022-11-10", "yyyy-mm-dd", null) });
            db.Movies.Add(new Movie { Name = "Мстители", Author = "Джон Сноу", CreatedBy = "Марвел", Date = DateTime.ParseExact("2022-02-10", "yyyy-mm-dd", null) });
            db.Movies.Add(new Movie { Name = "Большой куш", Author = "Ерлан Калиакпаров", CreatedBy = "Universal Pictures", Date = DateTime.ParseExact("2022-01-10", "yyyy-mm-dd", null) });
            db.Movies.Add(new Movie { Name = "Губка боб", Author = "Зедрик Африка", CreatedBy = "Universal Pictures", Date = DateTime.ParseExact("2022-09-10", "yyyy-mm-dd", null) });
        
            
            base.Seed(db);
        }
    }
}