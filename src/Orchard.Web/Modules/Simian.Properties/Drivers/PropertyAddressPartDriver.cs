using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Simian.Properties.Models;

namespace Simian.Properties.Drivers {
    public class PropertyAddressPartDriver : ContentPartDriver<PropertyAddressPart> {
        protected override string Prefix {
            get { return "PropertyAddress"; }
        }


        protected override DriverResult Display(PropertyAddressPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_PropertyAddress", () => shapeHelper.Parts_PropertyAddress(PropertyAddressPart: part));
        }

        //GET
        protected override DriverResult Editor(PropertyAddressPart part, dynamic shapeHelper) {
            return ContentShape("Parts_PropertyAddress_Edit",
                                () =>
                                shapeHelper.EditorTemplate(
                                    TemplateName: "Parts/PropertyAddress",
                                    Model: part,
                                    Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(PropertyAddressPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}