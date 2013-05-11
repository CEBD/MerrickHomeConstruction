using Harlin.Events.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;

namespace Harlin.Events.Drivers
{
    public class EventPartDriver : ContentPartDriver<EventPart>
    {

        protected override string Prefix
        {
            get
            {
                return "Event";
            }
        }

        protected override DriverResult Display(EventPart part, string displayType, dynamic shapeHelper) {

            return ContentShape("Parts_Event", () =>
                                               shapeHelper.Parts_Event(
                                                   EventPart: part
                                                   ));

        }


        //get
        protected override DriverResult Editor(EventPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Event_Edit",
                                () =>
                                shapeHelper.EditorTemplate(
                                    TemplateName: "Parts/Event",
                                    Model: part,
                                    Prefix: Prefix
                                    )
                );
        }
        //post
        protected override DriverResult Editor(EventPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            //you update the part, pas sin the prefix, and then theres whitelist and blacklist props (both null for now)

            updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part, shapeHelper);
        }

    }
}