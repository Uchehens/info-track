using InfoTrack.Infrastructure.Pesistance.Entities;
using System.Collections.Generic;

namespace InfoTrack.Infrastructure.Interface
{
    public interface ISearchEnginsService
    {
        Core.Models.SearchEngine GetSearchEngine(string url);
        string GetAllActiveSearchEngines();
    }
}