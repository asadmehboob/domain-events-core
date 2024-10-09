

using System;

namespace Catalog.Features.Events
{
    public class CatalogPriceChangedEvent : DomainEventBase
    {

        public CatalogPriceChangedEvent()
        {

        }
        public CatalogPriceChangedEvent(Guid id)
        {
            RandomId = id;
        }
        public Guid RandomId { get; set; }

    }
    

    



    
}
