using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ItStepSDP211.Models
{
    public class BuyTickets
    {
        public int BuyTicketsId { get; set; }
        public string Email { get; set; }
        public string Person { get; set; }
        public int Price { get; set; }
        public DateTime Date { get; set; }
    }
}