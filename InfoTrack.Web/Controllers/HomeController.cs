using InfoTrack.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using InfoTrack.Core.Interface;
using System.Security.Policy;
using System.Web;
using InfoTrack.Core.Models;
using InfoTrack.Infrastructure.Interface;

namespace InfoTrack.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        private readonly IProcessRequest _processRequest;
        private readonly ISearchEnginsService _searchEnginsService;
        private readonly AppSetting _appSetting;

        public HomeController(ILogger<HomeController> logger,
            IConfiguration configuration,
            IOptions<AppSetting> appsetting,
            ISearchEnginsService searchEnginsService,
            IProcessRequest processRequest)
        {
            _logger = logger;
            _configuration = configuration;
            _processRequest = processRequest;
            _appSetting = appsetting.Value;
            _searchEnginsService = searchEnginsService;

        }

        public IActionResult Index()
        {
            return View(new RankingModel());
        }

        [HttpPost]
        public IActionResult Index(Models.RankingModel ranking)
        {
            try
            {
                if (string.IsNullOrEmpty(ranking.engineUrl))
                {
                    TempData["Error"] = $"Kindly enter a valid search engine domain... ";
                    return View(ranking);
                }

                if (string.IsNullOrEmpty(ranking.keyWord))
                {
                    TempData["Error"] = $"Please enter a valid keywork";
                    return View(ranking);
                }

                var searchEngine = _searchEnginsService.GetSearchEngine(ranking.engineUrl);
                if (searchEngine == null)
                {
                    TempData["Error"] = $"Unknown search engine domain kindly use the following engines {_searchEnginsService.GetAllActiveSearchEngines()} ";
                    return View(ranking);
                }

                var request = new ProcessModel
                {
                    AppSetting = _appSetting,
                    SearchEngine = searchEngine,
                    SearchEngineIdentity = ranking.engineUrl,
                    SearchKeyworks = ranking.keyWord
                };

                var trending = _processRequest.Process(request);

                var result = new RankingModel
                {
                    Trending = trending.Trending,
                    filtered = trending.filtered,
                    unFiltered = trending.unfilteredRank,
                    SearchEngineIdentity = searchEngine.Identifier

                };


                return View(result);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
                //log4net or nlog to file
            }

            return Index();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        public JsonResult GetRecords(string s)
        {

            return Json(s); ;
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
