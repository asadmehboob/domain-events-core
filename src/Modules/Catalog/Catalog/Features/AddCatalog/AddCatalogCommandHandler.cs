using Ardalis.Result;
using Catalog.DTOs;
using MediatR;


namespace Catalog.Features.AddCatalog
{
    public class AddCatalogCommandHandler : IRequestHandler<AddCatalogCommand, Result<CatalogDto>>
    {
        private readonly ICatalogService _catalogService;
        private readonly ICatalogRepository _catalogRepository;

        public AddCatalogCommandHandler(ICatalogService catalogService, ICatalogRepository catalogRepository)
        {
            _catalogService = catalogService;
           _catalogRepository = catalogRepository;
        }
        public async Task<Result<CatalogDto>> Handle(AddCatalogCommand request, CancellationToken cancellationToken)
        {
            
            var newBook = new Catalog(Guid.NewGuid(), request.title, request.author, request.price);
            newBook.UpdatePrice(request.price);
            await _catalogService.AddCatalogAsync(newBook);
            //await _catalogRepository.AddAsync(newBook);
            //await _catalogRepository.SaveChangesAsync();

            return Result.Success(new CatalogDto(newBook.Id, newBook.Title, newBook.Author, newBook.Price));
           
        }
    }
}
