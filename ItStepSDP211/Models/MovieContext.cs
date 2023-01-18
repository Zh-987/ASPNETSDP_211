using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace ItStepSDP211.Models
{
    public class MovieContext : DbContext
    {
        public DbSet <Movie> Movies{ get; set; }
        public DbSet <BuyTickets> Tickets{ get; set; }

        public System.Data.Entity.DbSet<ItStepSDP211.Models.Player> Players { get; set; }

        public System.Data.Entity.DbSet<ItStepSDP211.Models.Team> Teams { get; set; }
    }
}