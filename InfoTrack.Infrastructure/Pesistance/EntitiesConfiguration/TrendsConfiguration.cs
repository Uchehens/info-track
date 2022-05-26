using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using InfoTrack.Infrastructure.Pesistance.Entities;

namespace InfoTrack.Infrastructure.Pesistance.EntitiesConfiguration
{
    public class TrendsConfiguration : IEntityTypeConfiguration<Trends>
    {
        public void Configure(EntityTypeBuilder<Trends> builder)
        {
            builder.Property(t =>t.Id).IsRequired()
                                    .UseIdentityColumn();
            builder.Property(t => t.Domain).HasMaxLength(100);
            builder.Property(t => t.Identity)
                                    .IsRequired()
                                    .HasMaxLength(100);
            builder.Property(t => t.FullUrl).HasMaxLength(4000);
            builder.Property(t => t.DateAdded).IsRequired();
        }
    }
}
