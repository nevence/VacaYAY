using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Configuration
{
    public class PositionConfiguration : IEntityTypeConfiguration<Position>
    {
        public void Configure(EntityTypeBuilder<Position> builder)
        {
            builder.Property(p => p.Caption).HasMaxLength(50).HasConversion<string>().IsRequired();
            builder.Property(p => p.Description).HasMaxLength(512).IsRequired();
            builder.Property(p => p.InsertDate).IsRequired();
            builder.HasQueryFilter(p => !p.IsDeleted);
            builder.HasIndex(p => p.IsDeleted)
            .HasFilter("IsDeleted = 0");
        }
    }
}
