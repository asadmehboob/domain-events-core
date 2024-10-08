using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Catalog.Features.Events
{
    public class SampleAddedEvent : DomainEventBase
    {
        public SampleAddedEvent()
        {
            
        }
        public SampleAddedEvent(Guid id)
        {
            RandomId = id;
        }
        public Guid RandomId { get; set; }
    }
}
