﻿
using MassTransit;
using Microsoft.Extensions.Logging;
using Shared.Messaging.Events;

namespace Basket.EventHanlders
{
    public class ProductPriceChangedIntegrationEventHandler : IConsumer<ProductPriceChangedIntegrationEvent>
    {
        private readonly ILogger<ProductPriceChangedIntegrationEventHandler>  _logger;

        public ProductPriceChangedIntegrationEventHandler(ILogger<ProductPriceChangedIntegrationEventHandler> logger)
        {
            _logger = logger;
        }
        public Task Consume(ConsumeContext<ProductPriceChangedIntegrationEvent> context)
        {
            _logger.LogInformation("Integration Event handled: {IntegrationEvent}", context.Message.GetType().Name);

            return Task.CompletedTask;
        }
    }
}
