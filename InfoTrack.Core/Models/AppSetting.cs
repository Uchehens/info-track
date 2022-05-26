using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Core.Models
{


    public class AppSetting
    {
        public Proxy Proxy { get; set; }
        public string Cookies {  get; set; }
        public string ExemptionList { get; set; }

    }

    public class Proxy
    {
        public bool isProxy { get; set; }
        public string Host { get; set; }
        public int Port { get; set; }
    }


}


