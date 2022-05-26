using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InfoTrack.Core.Interface;
using InfoTrack.Core.Models;

namespace InfoTrack.Infrastructure.Services
{
    public class CrawlerService 
    {
   
        public CrawlerModel Execute(CrawlerRequest _params)
        {
            try
            {
                var crawler = new Crawler(_params);
                var urls = crawler.RetriveAllUrl();
                var external = crawler.GetExternalSites(urls , _params.Identifier);
                var clearUrl = crawler.ClearUrl(external);
                var unfiltered = crawler.GetSiteRank(clearUrl);
                var uniqueSites = crawler.GetDistinctDomain(clearUrl);
                var filtered = crawler.GetSiteRank(uniqueSites);

               return new CrawlerModel
                {
                    filtered = filtered,
                    unfilteredRank = unfiltered,
                    sites = uniqueSites
                };
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public void SaveRecords(List<string> urls)
        {
          
        }

    }



}
