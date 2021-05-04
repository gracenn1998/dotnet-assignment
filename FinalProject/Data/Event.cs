using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalProject.Data
{
    public class Event
    {
        public int id { get; set; }
        public int userid { get; set; }
        public String title { get; set; }
        public String description { get; set; }
        public String color { get; set; }
        public DateTime start { get; set; }
        public DateTime end { get; set; }

    }
}