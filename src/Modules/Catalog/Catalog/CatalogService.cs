using Catalog.DTOs;

namespace Catalog;

internal class CatalogService : ICatalogService
{
    private readonly ICatalogRepository _CatalogRepo;

    public CatalogService(ICatalogRepository CatalogRepo)
    {
        _CatalogRepo = CatalogRepo;
    }

    public async Task AddCatalogAsync(Catalog CatalogDto)
    {
        //var Catalog = new Catalog(CatalogDto.Id, CatalogDto.Title, CatalogDto.Author, CatalogDto.Price);
        await _CatalogRepo.AddAsync(CatalogDto);
        await _CatalogRepo.SaveChangesAsync();
    }


    public async Task DeleteCatalogAsync(Guid id)
    {
        var Catalog = await _CatalogRepo.GetByIdAsync(id);
        if (Catalog == null) { }
        await _CatalogRepo.DeleteAsync(Catalog);
        await _CatalogRepo.SaveChangesAsync();
    }

    public Task<Catalog?> GetCatalogByIdAsync(Guid id)
    {
        var Catalog = _CatalogRepo.GetByIdAsync(id);
        if (Catalog == null) { }
        return Catalog;
    }

    public async Task<IList<CatalogDto>> ListCatalogsAsync()
    {
        var Catalogs = await _CatalogRepo.GetAllAsync();

        var dtoCatalogs = Catalogs.Select(b => new CatalogDto(b.Id, b.Title, b.Author, b.Price)).ToList();

        return dtoCatalogs;
    }

    public async Task UpdateCatalogPriceAsync(Guid id, decimal price)
    {
        var CatalogById = await _CatalogRepo.GetByIdAsync(id);
        if (CatalogById == null) { }
        CatalogById.UpdatePrice(price);

        await _CatalogRepo.SaveChangesAsync();


    }
}