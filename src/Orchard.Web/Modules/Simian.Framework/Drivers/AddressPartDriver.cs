
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Simian.Framework.Models;

namespace Simian.Framework.Drivers
{
    public class AddressPartDriver : ContentPartDriver<AddressPart> {
        protected override string Prefix
        {
            get { return "Address"; }
        }


        protected override DriverResult Display(AddressPart part, string displayType, dynamic shapeHelper) {
            return ContentShape("Parts_Address", () => shapeHelper.Parts_Address(
                AddressPart: part));
        }

        //GET
        protected override DriverResult Editor(AddressPart part, dynamic shapeHelper) {
            return ContentShape("Parts_Address_Edit",
                                () =>
                                shapeHelper.EditorTemplate(
                                    TemplateName: "Parts/Address",
                                    Model: part,
                                    Prefix: Prefix));
        }

        //POST
        protected override DriverResult Editor(AddressPart part, IUpdateModel updater, dynamic shapeHelper) {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }
    }
}