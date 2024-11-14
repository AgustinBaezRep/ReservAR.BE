using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using ReservAR.Domain.Common.Models;

namespace ReservAR.Infraestructure.Persistance.Interceptors
{
    public class SaveAuditableDataInterceptor : SaveChangesInterceptor
    {
        public override InterceptionResult<int> SavingChanges(DbContextEventData eventData, InterceptionResult<int> result)
        {
            SaveAuditableData(eventData.Context);
            return base.SavingChanges(eventData, result);
        }

        public override ValueTask<InterceptionResult<int>> SavingChangesAsync(DbContextEventData eventData, InterceptionResult<int> result, CancellationToken cancellationToken = default)
        {
            SaveAuditableData(eventData.Context);
            return base.SavingChangesAsync(eventData, result, cancellationToken);
        }

        private static void SaveAuditableData(DbContext? dbContext)
        {
            if (dbContext is null)
                return;

            var addedEntries = dbContext.ChangeTracker.Entries<IAuditableAggregate>().Where(e => e.State == EntityState.Added);
            if (addedEntries.Any())
                SaveCreatedEntries(addedEntries);

            var modifiedEntries = dbContext.ChangeTracker.Entries<IAuditableAggregate>().Where(e => e.State == EntityState.Modified);
            if (modifiedEntries.Any())
                SaveModifiedEntries(modifiedEntries);

            var deletedEntries = dbContext.ChangeTracker.Entries<IAuditableAggregate>().Where(e => e.State == EntityState.Deleted);
            if (deletedEntries.Any())
                SaveDeletedEntries(deletedEntries);
        }

        private static void SaveCreatedEntries(IEnumerable<EntityEntry<IAuditableAggregate>> addedEntries)
        {
            foreach (EntityEntry<IAuditableAggregate> addedEntry in addedEntries)
            {
                addedEntry.Entity.SetCreatedData(DateTime.UtcNow);
            }
        }

        private static void SaveModifiedEntries(IEnumerable<EntityEntry<IAuditableAggregate>> modifiedEntries)
        {
            foreach (EntityEntry<IAuditableAggregate> modifiedEntry in modifiedEntries)
            {
                modifiedEntry.Entity.SetUpdatedData(DateTime.UtcNow);
            }
        }

        private static void SaveDeletedEntries(IEnumerable<EntityEntry<IAuditableAggregate>> deletedEntries)
        {
            foreach (EntityEntry<IAuditableAggregate> deleteEntry in deletedEntries)
            {
                deleteEntry.State = EntityState.Modified;
                deleteEntry.Entity.SetDeletedData(DateTime.UtcNow);
            }
        }
    }
}
