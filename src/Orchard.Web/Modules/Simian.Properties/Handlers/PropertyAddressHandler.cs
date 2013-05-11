using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Simian.Properties.Models;

namespace Simian.Properties.Handlers {
    public class PropertyAddressHandler : ContentHandler {

        public PropertyAddressHandler(IRepository<PropertyAddressPartRecord> repo) {
            Filters.Add(StorageFilter.For(repo));
        }

    }
}