using InfoTrack.Core.Contants;
using InfoTrack.Core.Models;
using InfoTrack.Infrastructure.Pesistance.Entities;
using System.Collections.Generic;

namespace InfoTrack.Infrastructure.Interface
{
    public interface ITrendService
    {
        IEnumerable<Trends> GetCurrentTrends(string Identity);
        int? GetPostion(Trends current, List<Trends> previous);
        Refrence.Trend GetTrend(int? pos);
        IEnumerable<Trending> GetTrending(List<Trends> current, List<Trends> previous);
        List<Trends> SaveTrends(List<string> Urls, string Identity);
        void UpdateCurrentState(string Identity);
    }
}