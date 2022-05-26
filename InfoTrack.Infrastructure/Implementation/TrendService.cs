using InfoTrack.Infrastructure.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using InfoTrack.Core.Models;
using InfoTrack.Infrastructure.Pesistance.Entities;
using InfoTrack.Infrastructure.Interface;
using InfoTrack.Core.Contants;
using Microsoft.EntityFrameworkCore;


namespace InfoTrack.Infrastructure.Implementation
{
    public class TrendService : Repository<Trends>, ITrendService
    {

        public TrendService(InfoTrackContext infoTrackContext) : base(infoTrackContext) { }

        public List<Trends> SaveTrends(List<string> Urls, string Identity)
        {
            var trends = new List<Trends>();
            int count = 1;
            foreach (var url in Urls)
            {
                trends.Add(new Trends
                {
                    Identity = Identity,
                    Domain = url,
                    DateAdded = DateTime.Now,
                    Position = count++,
                    State = (int)Refrence.State.Current
                });
            }

            context.Trends.AddRange(trends);
            context.SaveChanges();
            return trends;
        }

        public void UpdateCurrentState(string Identity)
        {
            string sql = $"UPDATE Trends SET State = 1 WHERE [Identity] = '{Identity}'";
            context.Database.ExecuteSqlRaw(sql, string.Empty);
        }
        public IEnumerable<Trends> GetCurrentTrends(string Identity)
        {
            return context.Trends.Where(x => x.State == (int)Refrence.State.Current && x.Identity == Identity);
        }

        public IEnumerable<Trending> GetTrending(List<Trends> current, List<Trends> previous)
        {
            var trending = new List<Trending>();
            foreach (var trend in current)
            {
                var t = new Trending();
                t.Position = trend.Position ?? 0;
                t.Domain = trend.Domain;
                t.DateAdded = trend.DateAdded;

                var pos = GetPostion(trend, previous);
                t.Progress = (pos == null) ? 0 : Math.Abs((int)pos);
                t.Trend = GetTrend(pos);
                trending.Add(t);
            }
            return trending;
        }


        public int? GetPostion(Trends current, List<Trends> previous)
        {

            if (!previous.Any()) return null;
            var previousPosition = previous.Where(x => x.Domain == current.Domain);
            if (previousPosition.Any())
            {
                return (previousPosition.FirstOrDefault().Position - current.Position);
            }
            return null;
        }

        public Refrence.Trend GetTrend(int? pos)
        {
            if (pos > 0) return Refrence.Trend.Up;
            if (pos < 0) return Refrence.Trend.Down;
            if (pos == 0) return Refrence.Trend.Flat;
            return Refrence.Trend.Unknown;
        }

    }
}
