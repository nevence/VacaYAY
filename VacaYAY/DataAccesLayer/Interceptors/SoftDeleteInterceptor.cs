using DataAccesLayer.Entities;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccesLayer.Interceptors
{
    public sealed class SoftDeleteInterceptor : SaveChangesInterceptor
    {
        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(
            DbContextEventData eventData,
            InterceptionResult<int> result,
            CancellationToken cancellationToken = default)
        {
            if (eventData.Context is null)
            {
                return base.SavingChangesAsync(eventData, result, cancellationToken);
            }

            IEnumerable<EntityEntry<BaseEntity>> entries =
                eventData
                    .Context
                    .ChangeTracker
                    .Entries<BaseEntity>()
                    .Where(e => e.State == EntityState.Deleted);

            foreach (EntityEntry<BaseEntity> entityEntry in entries)
            {
                entityEntry.State = EntityState.Modified;
                entityEntry.Property("IsDeleted").CurrentValue = true;
                entityEntry.Property("DeleteDate").CurrentValue = DateTime.UtcNow;
            }

            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }
    }

}
