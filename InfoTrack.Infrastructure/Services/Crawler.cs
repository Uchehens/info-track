using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using InfoTrack.Core;
using System.Linq;
using InfoTrack.Core.Models;

namespace InfoTrack.Infrastructure.Services
{
    public class Crawler
    {
        private CrawlerRequest _crawler;
        //public int UnfilteredPosition { get; private set; }

        public Crawler(CrawlerRequest crawler)
        {
            _crawler = crawler;
        }


        public List<string> RetriveAllUrl()
        {
            if (string.IsNullOrEmpty(_crawler.siteData)) return new List<string>();
            var rx = new Regex(Constants.RegexHref, RegexOptions.IgnoreCase);
            return rx.Matches(_crawler.siteData)
                    .OfType<Match>()
                    .Select(x => x.Groups[Constants.HrefTag].Value)
                    .ToList();
        }


        public List<string> ClearUrl(List<string> sites)
        {
            Uri uriResult;
            List<string> results = new List<string>();
            foreach (var site in sites)
            {
                int index = site.IndexOf(Constants.HttpTag);
                if (index != -1 && !IsInExemptionList(site))
                {
                    if (Uri.TryCreate(site.Substring(index), UriKind.RelativeOrAbsolute, out uriResult))
                    {
                        results.Add($"{ uriResult.Scheme}://{uriResult.Host}");
                    }
                }
            }
            return results;
        }

        public bool IsExternalLink(string anchorLink, string searchEngineIdentity)
        {
            string dom = searchEngineIdentity.ToLower().
                Replace(Constants.WWW, string.Empty)
                .Trim();

            if (string.IsNullOrEmpty(anchorLink)) return false;

            if ((anchorLink.Contains(Constants.Http)
                || anchorLink.Contains(Constants.Https))
                && !anchorLink.Contains(dom))
                return true;

            return false;
        }

        public List<string> GetDistinctDomain(List<string> urls)
        {
            return urls.Distinct().ToList();

        }

        public int GetSiteRank(List<string> urls)
        {
            int count = 1;
            foreach (var domain in urls)
            {
                if (domain.Contains(Core.Constants.TomainToRank)) return count;
                count++;
            }
            return 0;
        }

        public List<string> GetExternalSites(List<string> urls, string searchEngine)
        {
            List<string> external = new List<string>();
            foreach (string url in urls)
            {
                if (IsExternalLink(url, searchEngine))
                {
                    external.Add(url);
                }
            }

           // return urls.Where(x => IsExternalLink(x, searchEngine) == true).Select(x => x);
            return external;
        }

        public bool IsInExemptionList(string value)
        {
            var items = _crawler.ExemptionList.Split(new char[] { Constants.Delimiter }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var item in items)
            {
                if (value.Contains(item)) return true;
            }

            //return items.Where(x=> x.Contains(value)).Any();
            return false;
        }

    }
}
