using InfoTrack.Core.Contants;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Core.Models
{
    public class Trending
    {
        public int Position { get; set; }
        public string Domain { get; set; }
        public DateTime DateAdded { get; set; }

        public int Progress { get; set; }

        public Refrence.Trend Trend { get; set; }

    }
}
