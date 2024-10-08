using MediatR;
using Microsoft.Extensions.Logging;


namespace Catalog.Features.Events
{
    public class SampleNotificationHandler : INotificationHandler<CatalogPriceChangedEvent>
    {
        private readonly ILogger<SampleNotificationHandler> _logger;

        public SampleNotificationHandler(ILogger<SampleNotificationHandler> logger)
        {
            _logger = logger;
        }
        public Task Handle(CatalogPriceChangedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Sample event triggerd.");
            return Task.CompletedTask;
        }
    }
}
