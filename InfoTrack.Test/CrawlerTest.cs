using System;
using System.Collections.Generic;
using System.IO;
using Xunit;

namespace InfoTrack.Test
{
    public class CrawlerTest
    {

        private const string ExemptionList = "w3/google/microsoft/live/wikipedia/facebook/linkedin/youtube/twitter";

        [Fact]
        public void ShouldGetAllUrlfromSiteData()
        {
            int num = new Random().Next(1, 6);
            string siteDate = System.IO.File.ReadAllText($@"..\..\..\Files\new{num}.html");
            var crawler = new InfoTrack.Infrastructure.Services.Crawler(new Core.Models.CrawlerRequest { siteData = siteDate });

            var allurl = crawler.RetriveAllUrl();

            Assert.NotEmpty(allurl);

        }


        [Fact]
        public void ShouldContainOnlyUrlStartingWithHttp()
        {
            var crawler = new InfoTrack.Infrastructure.Services.Crawler(new Core.Models.CrawlerRequest { ExemptionList = ExemptionList });

            var data = new List<string>
            {
                "kkkhttps://www.google.com",
                "http://www.man.com",
                "----https://home.com"
            };

            var expected = new List<string>
            {
                "https://www.google.com",
                "http://www.man.com",
                "https://home.com"
            };

            var result = crawler.ClearUrl(data);

            Assert.NotEmpty(result);
            Assert.Equal(2, result.Count); // google to be exempted
            Assert.NotEqual(expected, result);

        }

        [Theory]
        [InlineData("https://www.google.co.uk", "google", false)]
        [InlineData("https://www.infotrack.co.uk", "google", true)]
        [InlineData("https://www.gov.co.uk", "google", true)]
        [InlineData("https://www.google.com", "google", false)]
        [InlineData("https://www.infotrack.co.uk/download-a-brochure/", "google", true)]

        public void ShouldRetriveOnlyExternalSite(string url, string identity, bool expected)
        {
            var crawler = new InfoTrack.Infrastructure.Services.Crawler(null);

            var result = crawler.IsExternalLink(url, identity);

            Assert.Equal(expected, result);

        }

        [Fact]
        public void ShouldGetTheRankofDomainofIntrest()
        {
            var crawler = new InfoTrack.Infrastructure.Services.Crawler(null);

            var data = new List<string>
            {
                "kkkhttps//www.google.com",
                "http//www.man.com",
                "----https//home.com",
                "https//www.google.com",
                "https://www.infotrack.co.uk/download-a-brochure/",
                "http//www.man.com",
                "https//home.com"
            };

            var result = crawler.GetSiteRank(data);

            Assert.Equal(5, result);
        }
    }
}
