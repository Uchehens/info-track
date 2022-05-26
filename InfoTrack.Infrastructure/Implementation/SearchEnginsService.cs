using InfoTrack.Core.Interface;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InfoTrack.Infrastructure.Pesistance.Entities;
using InfoTrack.Infrastructure.Interface;
using InfoTrack.Infrastructure.Entities;

namespace InfoTrack.Infrastructure.Implementation
{


    public class SearchEnginsService : Repository<SearchEngine>, ISearchEnginsService
    {
        public SearchEnginsService(InfoTrackContext infoTrackContext) : base(infoTrackContext) { }
        public Core.Models.SearchEngine GetSearchEngine(string url)
        {
            var allEngins = context.SearchEngines.Where(x => x.IsActive);
            foreach (var engine in allEngins)
            {
                if (url.Contains(engine.Identifier, StringComparison.OrdinalIgnoreCase))
                {
                    {
                        return new Core.Models.SearchEngine
                        {
                            Accept = engine.Accept,
                            Cookie = engine.Cookie,
                            Domain = engine.Domain,
                            Identifier = engine.Identifier,
                            IsActive = engine.IsActive,
                            Method = engine.Method,
                            Query = engine.Query,
                            RequestPayload = engine.RequestPayload,
                            Id = engine.Id
                        };
                    }
                }

            }
            return null;
        }

        public string GetAllActiveSearchEngines()
        {
            string listOfEngins = string.Empty;
            var allEngins = context.SearchEngines.Where(x => x.IsActive).ToList();
            foreach (var engine in allEngins)
            {
                listOfEngins +=  $" {engine.Domain}, ";
            }

            return listOfEngins;
        }

    }

}


