namespace Catalog;

public interface IReadOnlyCatalogRepository
{
    Task<List<Catalog>> GetAllAsync();
    Task<Catalog?> GetByIdAsync(Guid id);
}
