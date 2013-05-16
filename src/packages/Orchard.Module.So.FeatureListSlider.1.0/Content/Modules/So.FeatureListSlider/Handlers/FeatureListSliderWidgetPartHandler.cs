using FeaturedItemSlider.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
using So.FeatureListSlider.Models;

namespace So.FeatureListSlider.Handlers {
    public class FeatureListSliderWidgetPartHandler : ContentHandler {
        public FeatureListSliderWidgetPartHandler(IRepository<FeatureListSliderWidgetPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}