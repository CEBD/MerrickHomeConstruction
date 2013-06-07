using Bing.Maps.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Bing.Maps.Handlers {
    public class MapHandler : ContentHandler {
        public MapHandler(IRepository<BingMapRecord> repository) {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}
