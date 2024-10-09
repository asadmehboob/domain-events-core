using MassTransit;
using MediatR;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;


namespace Catalog.Features.Events
{
    public class SampleNotificationHandler : INotificationHandler<CatalogPriceChangedEvent>
    {
        private readonly ILogger<SampleNotificationHandler> _logger;
        private readonly IBus _bus;

        public SampleNotificationHandler(
            ILogger<SampleNotificationHandler> logger,
            IBus bus
            )
        {
            _logger = logger;
            _bus = bus;
        }
        public async Task Handle(CatalogPriceChangedEvent notification, CancellationToken cancellationToken)
        {
            _logger.LogInformation("Domain Event handled: {DomainEvent}", notification.GetType().Name);

            var intEvent = new ProductPriceChangedIntegrationEvent
            {
                ProductId = notification.RandomId,
                Description = "Sample Integration Event",
                Price = 100
            };

           

            await _bus.Publish(intEvent, cancellationToken);

        }
    }
}
