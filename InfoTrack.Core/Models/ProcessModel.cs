using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Core.Models
{
    public class ProcessModel
    {
        public string SearchEngineIdentity { get; set; }
        public AppSetting AppSetting { get; set; }

        public SearchEngine SearchEngine { get; set; }
        public string SearchKeyworks { get; set; }
    }
}
