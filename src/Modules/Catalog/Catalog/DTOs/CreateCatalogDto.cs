namespace Catalog.DTOs
{
    public record CreateCatalogDto(Guid id, string Title, string Author, decimal Price);
}
