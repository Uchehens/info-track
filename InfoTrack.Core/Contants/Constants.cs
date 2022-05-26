using System;
using System.Collections.Generic;
using System.Text;
using static System.Net.WebRequestMethods;

namespace InfoTrack.Core
{
    public static class Constants
    {

        public const string RegexHref = "<a [^>]*href=(?:'(?<href>.*?)')|(?:\"(?<href>.*?)\")";
        public const string TomainToRank = "infotrack.co.uk";
        public const string HrefTag = "href";
        public const string Http = "http://";
        public const string Https = "https://";
        public const string HttpTag = "http";
        public const string WWW = "www";
        public const char Delimiter = '/';
        public const string ConnectionString = "";
        public const string GET = "GET";
    }


}

