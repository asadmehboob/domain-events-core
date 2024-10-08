namespace Catalog;

public interface ICatalogRepository : IReadOnlyCatalogRepository
{
    Task AddAsync(Catalog book);
    Task DeleteAsync(Catalog book);
    Task SaveChangesAsync();
}
