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
    public class VacationRequestConfiguration : IEntityTypeConfiguration<VacationRequest>
    {
        public void Configure(EntityTypeBuilder<VacationRequest> builder)
        {
            builder.HasKey(v => v.Id);
            builder.HasOne<Employee>(v => v.Employee).WithMany(e => e.VacationRequests).HasForeignKey(v => v.EmployeeId);
            builder.Property(v => v.StartDate).IsRequired();
            builder.Property(v => v.EndDate).IsRequired();
            builder.Property(v => v.Status).HasMaxLength(50).HasConversion<string>().IsRequired();
            builder.Property(v => v.LeaveType).HasMaxLength(50).HasConversion<string>(); ;
            builder.Property(v => v.HRComment).HasMaxLength(-1);
            builder.Property(v => v.EmployeeComment).HasMaxLength(-1);
            builder.Property(v => v.InsertDate).IsRequired();
        }
    }
}
