using Catalog.Features.Events;
using Shared.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;


namespace Catalog
{
    

    public class Catalog : IHaveDomainEvents
    {
        public Guid Id { get; private set; }
        public string Title { get; private set; } = string.Empty;

        public string Author { get; set; } = string.Empty;
        public decimal Price { get; set; }

        private List<DomainEventBase> _domainEvents = new();
        [NotMapped]
        public IEnumerable<DomainEventBase> DomainEvents => _domainEvents.AsReadOnly();
       

        public Catalog(Guid id, string title, string author, decimal price)
        {
            Id = id;
            Title = title;
            Author = author;
            Price = price;
        }

        

        protected void RegisterDomainEvent(DomainEventBase domainEvent)
        {
            _domainEvents.Add(domainEvent);
        }

        public void ClearDomainEvents()
        {
            _domainEvents.Clear();
        }

        public void UpdatePrice(decimal price)
        {

            Price = price;
            RegisterDomainEvent(new CatalogPriceChangedEvent(Guid.NewGuid()));
        }


    }

}
