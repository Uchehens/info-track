using InfoTrack.Core.Models;
using InfoTrack.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Linq;
using InfoTrack.Infrastructure.Interface;
using InfoTrack.Infrastructure.Network;

namespace InfoTrack.Infrastructure.Services
{
    public class ProcessRequest : WebClientWrapper, IProcessRequest
    {


        private readonly ITrendService _trendService;

        public ProcessRequest(ITrendService trendService)
        {
            _trendService = trendService;
        }
        public ProcessModelTrending Process(ProcessModel _params)
        {

            try
            {
                string siteData;
                _appSetting = _params.AppSetting;
                _appSetting.Cookies = _params.SearchEngine.Cookie;


                if (_params.SearchEngine.Method == Core.Constants.GET)
                    siteData = Get(_params.SearchEngine, _params.SearchKeyworks);
                else
                    siteData = Post(_params.SearchEngine, _params.SearchKeyworks);

                var crawler = new CrawlerService()
                             .Execute(new CrawlerRequest
                             {
                                 Identifier = _params.SearchEngine.Identifier,
                                 siteData = siteData,
                                 ExemptionList = _appSetting.ExemptionList
                             });

                //Get the Current as old in memeory
                var previousTrend = _trendService.GetCurrentTrends(_params.SearchEngine.Identifier).ToList();
                // Update All Trend
                _trendService.UpdateCurrentState(_params.SearchEngine.Identifier);
                //Save Trend and return the save trend as old
                var currentTrend = _trendService.SaveTrends(crawler.sites, _params.SearchEngine.Identifier);
                //GetTrend (by comparing current and old;
                var trending = _trendService.GetTrending(currentTrend, previousTrend);

                return new ProcessModelTrending
                {
                    filtered = crawler.filtered,
                    Trending = trending?.ToList(),
                    ranking = crawler.ranking,
                    sites = crawler.sites,
                    unfilteredRank = crawler.unfilteredRank

                };
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }


        private string Get(SearchEngine engine, string keyword)
        {
            string url = string.Format(engine.Query, HttpUtility.UrlEncode(keyword));
            return Get(url);
        }

        private string Post(SearchEngine engine, string keyword)
        {
            string request = string.Format(engine.RequestPayload, keyword);

            return Post(engine.Query, request);
        }
    }
}
