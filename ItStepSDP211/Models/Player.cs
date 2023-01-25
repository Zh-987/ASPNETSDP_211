using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ItStepSDP211.Models
{
    public class Player
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Position { get; set; }
        public int? TeamId { get; set; }
        public Team Team { get; set; }

    }

    public class Team
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Coach { get; set; }

        public ICollection<Player> Players { get; set; }
        public Team()
        {
            Players = new List<Player>();
        }
    }

    public class PlayersListViewModel
    {
        public IEnumerable<Player> Players { get; set; }
        public SelectList Position { get; set; }
        public SelectList Team { get; set; }
    }

    public class MenuItem
    {
        public int Id { get; set; }
        public string Header { get; set; } // загаловком 
        public string Url { get; set; }
        public int? Order { get; set; }
        public int? ParentId { get; set; }
        public MenuItem Parent { get; set; }
        public ICollection<MenuItem> Children { get; set; }
        public MenuItem(){
            Children = new List<MenuItem>();
        }
    }

}