using MediatR;
using Ardalis.Result;
using Catalog.DTOs;

namespace Catalog.Features.AddCatalog
{
    public record AddCatalogCommand(string title, string author, decimal price) : IRequest<Result<CatalogDto>>;
    
}
