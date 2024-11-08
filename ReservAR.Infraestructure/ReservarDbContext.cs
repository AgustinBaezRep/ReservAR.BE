using Microsoft.EntityFrameworkCore;

namespace ReservAR.Infraestructure
{
    public class ReservarDbContext : DbContext
    {
        public ReservarDbContext(DbContextOptions<ReservarDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfigurationsFromAssembly(typeof(ReservarDbContext).Assembly);

            base.OnModelCreating(builder);
        }
    }
}
