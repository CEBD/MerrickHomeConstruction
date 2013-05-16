using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Nine.FieldbookSales
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            ContentDefinitionManager
                .AlterPartDefinition("FeaturePart", partBuilder =>
                                                    partBuilder
                                                        .Attachable()


                                                        .WithField("FeatureCategory", f =>
                                                                                                        f.OfType("TaxonomyField")
                                                                                                         .WithDisplayName("FeatureCategory")
                                                                                                         .WithSetting("TaxonomyFieldSettings.Taxonomy", "FeatureCategory")
                                                                                                         .WithSetting("TaxonomyFieldSettings.LeavesOnly", "False")
                                                                                                         .WithSetting("TaxonomyFieldSettings.SingleChoice", "True")
                                                                                                         .WithSetting("TaxonomyFieldSettings.Hint", "Please select what kind of feature you are posting.")
                                                                             )


                                                        //Teaser
                                                        .WithField("TeaserBannerFeatureCallout", f => f.OfType("TextField").WithDisplayName("Teaser Banner  Callout"))
                                                        .WithField("TeaserLeftFeatureCallout", f => f.OfType("TextField").WithDisplayName("Teaser Left  Callout"))
                                                        .WithField("TeaserRightFeatureCallout", f => f.OfType("TextField").WithDisplayName("Teaser Right  Callout"))

                                                        .WithField("FeatureTeaser", f => f.OfType("TextField").WithDisplayName("Teaser").WithSetting("TextFieldSettings.Flavor", "Html").WithSetting("TextFieldSettings.Required", "true"))

                                                        .WithField("TeaserBannerFeatureImage", f => f.OfType("MediaPickerField").WithDisplayName("Teaser Banner  Image"))
                                                        .WithField("TeaserLeftFeatureImage", f => f.OfType("MediaPickerField").WithDisplayName("Teaser Left  Image"))
                                                        .WithField("TeaserRightFeatureImage", f => f.OfType("MediaPickerField").WithDisplayName("Teaser Right  Image"))

                                                        //Learn More
                                                        .WithField("LearnMoreBannerFeatureCallout", f => f.OfType("TextField").WithDisplayName("LearnMore Banner  Callout"))
                                                        .WithField("LearnMoreLeftFeatureCallout", f => f.OfType("TextField").WithDisplayName("LearnMore Left  Callout"))
                                                        .WithField("LearnMoreRightFeatureCallout", f => f.OfType("TextField").WithDisplayName("LearnMore Right  Callout"))
                                       
                                                        .WithField("FeatureLearnMore", f => f.OfType("TextField").WithDisplayName("Learn More").WithSetting("TextFieldSettings.Flavor", "Html"))

                                                        .WithField("LearnMoreBannerFeatureImage", f => f.OfType("MediaPickerField").WithDisplayName("LearnMore Banner  Image"))
                                                        .WithField("LearnMoreLeftFeatureImage", f => f.OfType("MediaPickerField").WithDisplayName("LearnMore Left  Image"))
                                                        .WithField("LearnMoreRightFeatureImage", f => f.OfType("MediaPickerField").WithDisplayName("LearnMore Right  Image"))
                                                        
                      
                );

            ContentDefinitionManager
                .AlterTypeDefinition("Feature", builder =>
                                                builder
                                                    .WithPart("CommonPart")
                                                    .WithPart("TitlePart")
                                                    //.WithPart("BodyPart")
                                                    .WithPart("FeaturePart")
                                                    .WithPart("AutoroutePart",
                                                              partBuilder =>
                                                              partBuilder
                                                                  .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                                                                  .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                                                                  .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name: 'Feature Title', Pattern: 'features/{Content.Slug}', Description: 'properties/feature-title'}]")
                                                                  .WithSetting("AutorouteSettings.DefaultPatternIndex", "0")
                                                    )
                                                    .Creatable()
                                                    .Draftable()
                );
            return 1;
        }
    }
}