using System.Data;
using Orchard.ContentManagement.MetaData;
using Orchard.Data.Migration;
using So.FeatureListSlider.Models;
using FeaturedItemSlider.Models;

namespace So.FeatureListSlider
{
    public class Migrations : DataMigrationImpl 
    {
        public int Create() 
        {
            SchemaBuilder.CreateTable(typeof(FeatureListSliderWidgetPartRecord).Name, builder => builder
                .ContentPartRecord()
                .Column<string>("GroupName", col => col.WithLength(100))
            );

            ContentDefinitionManager.AlterTypeDefinition("FeatureListSliderWidget", builder => builder
                .WithPart(typeof(FeatureListSliderWidgetPart).Name)
                .WithPart("CommonPart")
                .WithPart("WidgetPart")
                .WithPart("IdentityPart")
                .WithSetting("Stereotype", "Widget")
            );
            ContentDefinitionManager.AlterPartDefinition("FeaturedItemPart", builder => builder.WithField("FeatureListSliderIcon", cfg => cfg.OfType("MediaPickerField")));
            return 1;
        }
    }
}