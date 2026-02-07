using Microsoft.EntityFrameworkCore;
using ReservAR.Domain.AtributoAggregate;
using ReservAR.Domain.CanchaAggregate;
using ReservAR.Domain.Common.Models;
using ReservAR.Domain.ComplejoAggregate;
using ReservAR.Domain.ConsumoAggregate;
using ReservAR.Domain.DeporteAggregate;
using ReservAR.Domain.DireccionAggregate;
using ReservAR.Domain.DisponibilidadHorariaAggregate;
using ReservAR.Domain.PisoAggregate;
using ReservAR.Domain.PrecioAggregate;
using ReservAR.Domain.ProductoAggregate;
using ReservAR.Domain.ProductoConsumoAggregate;
using ReservAR.Domain.ReservaAggregate;
using ReservAR.Domain.RolAggregate;
using ReservAR.Domain.ServicioAggregate;
using ReservAR.Domain.UserAggregate;
using ReservAR.Infraestructure.Persistance.OutboxMessages;

namespace ReservAR.Infraestructure.Persistance
{
    public class ReservarDbContext(DbContextOptions<ReservarDbContext> options) : DbContext(options)
    {
        public DbSet<OutboxMessage> OutboxMessages => Set<OutboxMessage>();
        public DbSet<Cancha> Canchas => Set<Cancha>();
        public DbSet<AtributoCancha> AtributoCanchas => Set<AtributoCancha>();
        public DbSet<Reserva> Reservas => Set<Reserva>();
        public DbSet<Complejo> Complejos => Set<Complejo>();
        public DbSet<ServicioComplejo> ServiciosComplejo => Set<ServicioComplejo>();
        public DbSet<Consumo> Consumos => Set<Consumo>();
        public DbSet<ProductoConsumo> ProductosConsumo => Set<ProductoConsumo>();
        public DbSet<Producto> Productos => Set<Producto>();
        public DbSet<Servicio> Servicios => Set<Servicio>();
        public DbSet<DisponibilidadHoraria> DisponibilidadesHorarias => Set<DisponibilidadHoraria>();
        public DbSet<Usuario> Usuarios => Set<Usuario>();
        public DbSet<Rol> Roles => Set<Rol>();
        public DbSet<Direccion> Direcciones => Set<Direccion>();
        public DbSet<Precio> Precios => Set<Precio>();
        public DbSet<Deporte> Deportes => Set<Deporte>();
        public DbSet<Piso> Pisos => Set<Piso>();
        public DbSet<Atributo> Atributos => Set<Atributo>();

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(ReservarDbContext).Assembly);

            builder.Entity<Cancha>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Reserva>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Complejo>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Consumo>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<ProductoConsumo>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Producto>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Servicio>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<DisponibilidadHoraria>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Usuario>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Rol>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Direccion>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Precio>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Deporte>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Piso>().HasQueryFilter(r => !r.IsDeleted);
            builder.Entity<Atributo>().HasQueryFilter(r => !r.IsDeleted);

            base.OnModelCreating(builder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }
    }
}
