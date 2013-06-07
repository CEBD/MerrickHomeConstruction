using Bing.Maps.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Bing.Maps.Drivers {
    public class BingMapDriver : ContentPartDriver<BingMapPart> {
        protected override DriverResult Display(BingMapPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_BingMap",
                                () => shapeHelper.Parts_BingMap(
                                    Longitude: part.Longitude,
                                    Latitude: part.Latitude,
                                    Width: part.Width,
                                    Height: part.Height,
                                    Zoom: part.Zoom,
                                    Mode: part.Mode));
        }

        //GET
        protected override DriverResult Editor(BingMapPart part, dynamic shapeHelper) {
            return ContentShape("Parts_BingMap_Edit",
                                () => shapeHelper.EditorTemplate(TemplateName: "Parts/BingMap", Model: part, Prefix: Prefix));
        }
        //POST
        protected override DriverResult Editor(BingMapPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}
