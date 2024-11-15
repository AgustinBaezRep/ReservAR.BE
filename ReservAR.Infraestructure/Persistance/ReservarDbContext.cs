using Microsoft.EntityFrameworkCore;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.UserAggregate;

namespace ReservAR.Infraestructure.Persistance
{
    public class ReservarDbContext(DbContextOptions<ReservarDbContext> options) : DbContext(options)
    {
        public DbSet<User> Users => Set<User>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(ReservarDbContext).Assembly);

            builder.Entity<User>().HasQueryFilter(r => !r.IsDeleted);

            base.OnModelCreating(builder);
        }
    }
}
