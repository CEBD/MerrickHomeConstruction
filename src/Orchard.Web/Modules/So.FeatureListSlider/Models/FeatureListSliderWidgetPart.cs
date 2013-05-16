using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using So.FeatureListSlider.Models;

namespace FeaturedItemSlider.Models {
    public class FeatureListSliderWidgetPart : ContentPart<FeatureListSliderWidgetPartRecord>
    {        
        [Required(ErrorMessage = "You must have a Feature Group to associate with this widget")]
        public string GroupName {
            get { return Record.GroupName; }
            set { Record.GroupName = value; }
        }
    }
}