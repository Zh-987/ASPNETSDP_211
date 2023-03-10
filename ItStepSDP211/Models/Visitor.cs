using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ItStepSDP211.Models
{
    public class Visitor
    {
        public int Id { get; set; }
        public string Login { get; set; }
        public string Ip { get; set; }
        public string Url { get; set; }
        public DateTime Date { get; set; }
    }

   

    public class ExceptionDetail
    {
        public int Id { get; set; }
        public string ExceptionMessage { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string StackTrace { get; set; }
        public DateTime Date { get; set; }

    }
    public class LogContext : DbContext
    {
        public DbSet<Visitor> Visitors;
        public DbSet<ExceptionDetail> ExceptionDetails;
    }
}