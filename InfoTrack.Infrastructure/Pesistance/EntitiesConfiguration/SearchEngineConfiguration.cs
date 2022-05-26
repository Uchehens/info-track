using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using InfoTrack.Infrastructure.Pesistance.Entities;

namespace InfoTrack.Infrastructure.Pesistance.EntitiesConfiguration
{
    public class SearchEngineConfiguration : IEntityTypeConfiguration<SearchEngine>
    {
        public void Configure(EntityTypeBuilder<SearchEngine> builder)
        {
            builder.Property(t => t.Id).IsRequired()
                                    .UseIdentityColumn();
            builder.Property(t => t.Identifier).HasMaxLength(100);
            builder.Property(t => t.Domain).HasMaxLength(100);
            builder.Property(t => t.Method).HasMaxLength(10);
            builder.Property(t => t.Query).HasMaxLength(100);
            builder.Property(t => t.Accept).HasMaxLength(100);
            builder.Property(t => t.RequestPayload).HasMaxLength(2000);
            builder.Property(t => t.Cookie).HasMaxLength(2000);

        }
    }
}
