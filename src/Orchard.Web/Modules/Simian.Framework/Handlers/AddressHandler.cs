using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using Simian.Framework.Models;

namespace Simian.Framework.Handlers
{
    public class AddressHandler : ContentHandler {

        public AddressHandler(IRepository<AddressPartRecord> repo) {
            Filters.Add(StorageFilter.For(repo));
        }

    }
}