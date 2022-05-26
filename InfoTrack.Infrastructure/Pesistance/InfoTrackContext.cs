using Microsoft.EntityFrameworkCore;
using InfoTrack.Infrastructure.Pesistance.EntitiesConfiguration;
using System.Reflection;
using InfoTrack.Infrastructure.Pesistance.Entities;

namespace InfoTrack.Infrastructure.Entities
{
    public class InfoTrackContext : DbContext
    {
        public DbSet<Trends> Trends { get; set; }
        public DbSet<SearchEngine> SearchEngines { get; set; }
        public InfoTrackContext(DbContextOptions<InfoTrackContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.ApplyConfiguration(new TrendsConfiguration());
            modelBuilder.ApplyConfiguration(new SearchEngineConfiguration());

            modelBuilder.Seed();
            //modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }


    }
}
