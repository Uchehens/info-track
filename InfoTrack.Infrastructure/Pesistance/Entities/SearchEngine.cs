using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Infrastructure.Pesistance.Entities
{
    public class SearchEngine
    {
       public int Id {  get; set; }
        public string Identifier { get; set; }    
        public string Domain { get; set; }
        public string Method { get; set; }
        public string Query { get; set; }
        public string Accept { get; set; }
        public string RequestPayload { get; set; }
        public string Cookie { get; set; }
        public bool IsActive { get; set; }


    }
}
