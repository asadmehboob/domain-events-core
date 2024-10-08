

using Microsoft.EntityFrameworkCore;

namespace Catalog.Data
{
    public class EfCatalogRepository : ICatalogRepository
    {
        private readonly CatalogDbContext _dbContext;

        public EfCatalogRepository(CatalogDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public Task AddAsync(Catalog Catalog)
        {
            _dbContext.Catalogs.Add(Catalog);
            return Task.CompletedTask;
        }

        public Task DeleteAsync(Catalog Catalog)
        {
            _dbContext.Catalogs.Remove(Catalog);
            return Task.CompletedTask;
        }

        public async Task<Catalog?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Catalogs.FindAsync(id);
        }

        public async Task<List<Catalog>> GetAllAsync()
        {
            return await _dbContext.Catalogs.ToListAsync();
        }

        public async Task SaveChangesAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }

}
