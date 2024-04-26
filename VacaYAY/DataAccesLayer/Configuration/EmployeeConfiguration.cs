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
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee>
    {
        public void Configure(EntityTypeBuilder<Employee> builder)
        {
            builder.Property(e => e.FirstName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.LastName).HasMaxLength(50).IsRequired();
            builder.Property(e => e.Address).HasMaxLength(512).IsRequired();
            builder.Property(e => e.DaysOffNumber).IsRequired();
            builder.Property(e => e.EmploymentStartDate).IsRequired();
            builder.Property(e => e.InsertDate).IsRequired();
        }
    }
}
