namespace Shared.Interfaces
{
    public interface IHaveDomainEvents
    {
        IEnumerable<DomainEventBase> DomainEvents { get; }
        void ClearDomainEvents();
    }
}
