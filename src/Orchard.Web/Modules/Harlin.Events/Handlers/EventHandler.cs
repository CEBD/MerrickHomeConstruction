using Harlin.Events.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Harlin.Events.Handlers
{
    public class EventHandler : ContentHandler
    {
        public EventHandler(IRepository<EventPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}