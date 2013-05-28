using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Simian.Framework {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            // Creating table AddressPartRecord
            SchemaBuilder.CreateTable("AddressPartRecord", table =>
                                                           table
                                                               .ContentPartRecord()
                                                               .Column<double>("Latitude")
                                                               .Column<double>("Longitude")
                                                               .Column<string>("City")
                                                               .Column<string>("State")
                                                               .Column<string>("Zipcode")
                                                               .Column<string>("Street")
                );

            ContentDefinitionManager.AlterPartDefinition("AddressPart", builder => builder.Attachable());


            ContentDefinitionManager.AlterPartDefinition("GalleriaPart", part =>
                                                                         part.Attachable()
                                                                             .WithField("ImageGallery", f =>
                                                                                                        f.OfType("ImageMultiPickerField")
                                                                                                         .WithDisplayName("Image Gallery")
                                                                                                         .WithSetting("ImageMultiPickerFieldSettings.CustomFields", "[{name: 'title', displayName: 'Title', type:'text'},{name: 'description', displayName: 'Description', type:'textarea'}]")
                                                                             ));


            ContentDefinitionManager.AlterTypeDefinition("GalleriaImageGalleryWidget",
                                                         b => b
                                                                  .WithPart("GalleriaPart")
                                                                  .WithPart("WidgetPart")
                                                                  .WithPart("CommonPart")
                                                                  .WithSetting("Stereotype", "Widget")
                );


            return 1;
        }
    }
}