using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Infrastructure.Pesistance.Entities
{
    public class Trends
    {
        public int Id { get; set; }
        public string Domain { get; set; }
        public string Identity { get; set; }
        public string FullUrl { get; set; }
        public DateTime DateAdded { get; set; }
        public int State { get; set; }
        public int? Position { get; set;  }

    }
}
