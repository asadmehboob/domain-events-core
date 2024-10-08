using Catalog.DTOs;
using Catalog.Features.AddCatalog;
using MediatR;
using Microsoft.AspNetCore.Mvc;


namespace Catalog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CatalogController : ControllerBase
    {
        private readonly ISender _sender;

        public CatalogController(ISender sender)
        {
            _sender = sender;
        }

        [HttpPost]
        public async Task<ActionResult<CatalogDto>> CreateCatalog(CreateCatalogDto model)
        {
            var catRequest = new AddCatalogCommand(model.Title, model.Author, model.Price);

            var result = await _sender.Send(catRequest);

            return Ok(result.Value);

        }
    }
}
