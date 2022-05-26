using InfoTrack.Core.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrack.Web.Models
{
    public class RankingModel
    {
        public List<Trending> Trending { get; set; } = new List<Trending>();
        public int filtered { get; set; } = 0;
        public int unFiltered { get; set; } = 0;
        public string  SearchEngineIdentity { get; set;  }


        [Required]
        [DataType(DataType.Url)]
        public string engineUrl { get; set; }

        [Required]
        [DataType(DataType.Text)]
        public string keyWord { get; set; }



    }
}
