using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Simian.Properties.Models;

namespace Simian.Properties {
    public class Migrations : DataMigrationImpl {
        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Property", builder =>
                                                                     builder
                                                                         .WithPart("CommonPart")
                                                                         .WithPart("TitlePart")
                                                                         .WithPart("AutoroutePart")
                                                                         .WithPart("BodyPart")
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

        public int UpdateFrom1() {
            SchemaBuilder.CreateTable("PropertyAddressPartRecord", table =>
                                                               table.ContentPartRecord()
                                                                    .Column<double>("Latitude")
                                                                    .Column<double>("Longitude")
                                                                    .Column<string>("City")
                                                                    .Column<string>("State")
                                                                    .Column<string>("Zipcode")
                                                                    .Column<string>("Street")
                );

            

            ContentDefinitionManager.AlterTypeDefinition("Property", builder =>
                                                                     builder.WithPart("PropertyAddressPart")
                                                                     );
            return 2;
        }


    }
}