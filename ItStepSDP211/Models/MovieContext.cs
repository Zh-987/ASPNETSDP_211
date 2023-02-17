using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ItStepSDP211.Models
{
    public class MovieContext : DbContext
    {
        public MovieContext() : base("DefaultConnection") { }
        public DbSet<Movie> movie { get; set; }
    }

    public interface IRepository{
        void Save(Movie m);
        void Remove(int id);
        IEnumerable<Movie> List();
        Movie Get(int id);
    }
 
    public class MovieRepository : IDisposable, IRepository {
        private MovieContext db;

        /*   public MovieRepository(MovieContext context, string connectionString) {

               db = context;
           }*/

        public MovieContext Context {
            get { return db; }
            set { db = value}
        }
        public void Save(Movie m) {
            db.movie.Add(m);
            db.SaveChanges();
        }
        public void Remove(int id) {
            Movie movie = db.movie.Find(id);
            db.movie.Remove(movie);
            db.SaveChanges();
        }
        public IEnumerable<Movie> List()
        {
            return db.movie;
        }
        public Movie Get(int id) {
            return db.movie.Find(id);
        }

        
        protected void Dispose(bool disposing) {
            if (disposing) {
                if (db != null) {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }

    public class MySqlRepository : IDisposable, IRepository
    {
        private MovieContext db = new MovieContext();
        public void Save(Movie m)
        {
            db.movie.Add(m);
            db.SaveChanges();
        }
        public void Remove(int id)
        {
            Movie movie = db.movie.Find(id);
            db.movie.Remove(movie);
            db.SaveChanges();
        }
        public IEnumerable<Movie> List()
        {
            return db.movie;
        }
        public Movie Get(int id)
        {
            return db.movie.Find(id);
        }


        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (db != null)
                {
                    db.Dispose();
                    db = null;
                }
            }
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }

}