using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Simian.Properties
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("PropertyAddressPartRecord", table =>
                                                                   table.ContentPartRecord()
                                                                        .Column<double>("Latitude")
                                                                        .Column<double>("Longitude")
                                                                        .Column<string>("City")
                                                                        .Column<string>("State")
                                                                        .Column<string>("Zipcode")
                                                                        .Column<string>("Street")
                );

            ContentDefinitionManager.AlterPartDefinition("PropertyPart", part =>
                                                                         part
                                                                             .Attachable()
                                                                             .WithField("PropertyType", f =>
                                                                                                        f.OfType("TaxonomyField")
                                                                                                         .WithDisplayName("PropertyType")
                                                                                                         .WithSetting("TaxonomyFieldSettings.Taxonomy", "PropertyType")
                                                                                                         .WithSetting("TaxonomyFieldSettings.LeavesOnly", "False")
                                                                                                         .WithSetting("TaxonomyFieldSettings.SingleChoice", "True")
                                                                                                         .WithSetting("TaxonomyFieldSettings.Hint", "Please select what kind of property you are posting.")
                                                                             )
                                                                             .WithField("Ammenities", f =>
                                                                                                      f.OfType("TaxonomyField")
                                                                                                       .WithDisplayName("Ammenities")
                                                                                                       .WithSetting("TaxonomyFieldSettings.Taxonomy", "Ammenities")
                                                                                                       .WithSetting("TaxonomyFieldSettings.LeavesOnly", "False")
                                                                                                       .WithSetting("TaxonomyFieldSettings.SingleChoice", "False")
                                                                                                       .WithSetting("TaxonomyFieldSettings.Hint", "Please select the ammenities available on this property")
                                                                             )
                                                                             .WithField("RentOrSale", f =>
                                                                                                      f.OfType("TaxonomyField")
                                                                                                       .WithDisplayName("RentOrSale")
                                                                                                       .WithSetting("TaxonomyFieldSettings.Taxonomy", "RentOrSale")
                                                                                                       .WithSetting("TaxonomyFieldSettings.LeavesOnly", "False")
                                                                                                       .WithSetting("TaxonomyFieldSettings.SingleChoice", "True")
                                                                                                       .WithSetting("TaxonomyFieldSettings.Hint", "Is this property for rent or sale?")
                                                                             )
                                                                             .WithField("Available", f =>
                                                                                                     f.OfType("BooleanField")
                                                                                                      .WithDisplayName("Available")
                                                                                                      .WithSetting("BooleanFieldSetting.OnLabel", "This property is available!")
                                                                                                      .WithSetting("BooleanFieldSetting.OffLabel", "This property currently unavailable.")
                                                                             )
                                                                             .WithField("Bedrooms", f =>
                                                                                                    f.OfType("TextField")
                                                                                                     .WithDisplayName("Bedrooms")
                                                                             )
                                                                             .WithField("Bathrooms", f => f.OfType("TextField")
                                                                                                           .WithDisplayName("Bathrooms")
                                                                             )
                                                                             .WithField("FloorplanImage", f => f.OfType("MediaPickerField").WithDisplayName("Floor Plan")
                                                                             
                                                                             )
                                                                             .WithField("PropertyImageGallery", f => f.OfType("ImageMultiPickerField").WithDisplayName("Property Image Gallery")
                                                                             
                                                                             )
                );


            ContentDefinitionManager.AlterTypeDefinition("Property", builder =>
                                                                     builder
                                                                         .WithPart("CommonPart")
                                                                         .WithPart("TitlePart")
                                                                         .WithPart("BodyPart")
                                                                         .WithPart("PublishLaterPart")
                                                                         .WithPart("PropertyAddressPart")
                                                                         .WithPart("PropertyPart")
                                                                         .WithPart("AutoroutePart", partBuilder =>
                                                                                                    partBuilder
                                                                                                        .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                                                                                                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                                                                                                        .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name: 'Property Title', Pattern: 'properties/{Content.Slug}', Description: 'properties/property-title'}]")
                                                                                                        .WithSetting("AutorouteSettings.DefaultPatternIndex", "0")
                                                                         )
                                                                         .Creatable()
                                                                         .Draftable()
                );


            return 1;
        }
    }
}