using Catalog.DTOs;

namespace Catalog;

public interface ICatalogService
{
    Task<IList<CatalogDto>> ListCatalogsAsync();
    Task<Catalog?> GetCatalogByIdAsync(Guid id);
    Task AddCatalogAsync(Catalog CatalogDto);

    Task UpdateCatalogPriceAsync(Guid id, decimal newPrice);
    Task DeleteCatalogAsync(Guid id);


}
