using Microsoft.AspNetCore.Components;
using Microsoft.EntityFrameworkCore;
using Shared.Interfaces;
using System.Reflection;

namespace Catalog.Data
{
  
    public class CatalogDbContext : DbContext
    {
        private readonly IDomainEventDispatcher? _dispatcher;
        public CatalogDbContext(DbContextOptions<CatalogDbContext> options, IDomainEventDispatcher dispatcher) : base(options)
        {
            _dispatcher = dispatcher;
        }

        public DbSet<Catalog> Catalogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasDefaultSchema("Catalogs");
            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
            base.OnModelCreating(modelBuilder);
        }

        protected override void ConfigureConventions(ModelConfigurationBuilder configurationBuilder)
        {
            configurationBuilder.Properties<decimal>().HavePrecision(18, 6);

        }

        public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new CancellationToken())
        {
            int result = await base.SaveChangesAsync(cancellationToken).ConfigureAwait(false);

            // ignore events if no dispatcher provided
            if (_dispatcher == null) return result;

            var entities = ChangeTracker.Entries<IHaveDomainEvents>();
            // dispatch events only if save was successful
            var entitiesWithEvents = ChangeTracker.Entries<IHaveDomainEvents>()
                .Select(e => e.Entity)
            .Where(e => e.DomainEvents.Any())
            .ToArray();

            await _dispatcher.DispatchAndClearEvents(entitiesWithEvents);

            return result;
        }



    }
}
