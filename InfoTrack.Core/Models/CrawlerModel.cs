using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Core.Models
{
    public class CrawlerModel
    {
        public List<string> sites = new List<string>();
        public int ranking { get; set; }
        public int unfilteredRank { get; set; }
        public int filtered { get; set; }
    }


    public class CrawlerRequest
    {
        public string siteData { get; set; }
        public string Identifier { get; set; }
        public string ExemptionList { get; set; }

    }

}
