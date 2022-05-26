using InfoTrack.Infrastructure.Pesistance.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace InfoTrack.Infrastructure.Pesistance.EntitiesConfiguration
{
    public static class ModelBuilderExtension
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<SearchEngine>().HasData(
                new SearchEngine
                {
                    Id = 1,
                    Accept = "text/plain",
                    Identifier = "google",
                    IsActive = true,
                    Method = "GET",
                    Query = "https://www.google.co.uk/search?num=100&q={0}",
                    Domain = "google.uk.co",
                    RequestPayload = "",
                    Cookie = "1P_JAR=2021-08-25-19; CONSENT=YES+srp.gws-20210816-0-RC3.en+FX+146; NID=222=AmjNKzCPWZjOOlug3HXE063uyLK02Twke1WC05QsXNsr6CAFLNvKL9xuUtkHniPmKPG-HfhrVSYYID4GiQ1WQxu5gUahwchMX9DWAR7TvyNE2YgowxoLZeGMnSnq3tTjfmUCVGmd9QMes__5rpjG6bDDmo6YiEE6so4phO2Vyrc"
                }
            );
        }
    }
}
