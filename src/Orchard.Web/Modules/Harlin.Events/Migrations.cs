using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Harlin.Events {
    public class Migrations : DataMigrationImpl {

        public int Create() {
            ContentDefinitionManager.AlterTypeDefinition("Event", builder => 
                builder
                .WithPart("CommonPart")
                .WithPart("TitlePart")
                .WithPart("AutoroutePart")
                .WithPart("BodyPart")
                .WithPart("AutoroutePart", partBuilder =>
                    partBuilder
                    .WithSetting("AutorouteSettings.AllowCustomPattern", "true")
                    .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "false")
                    .WithSetting("AutorouteSettings.PatternDefinitions", "[{Name: 'Event Title', Pattern: 'events/{Content.Slug}', Description: 'events/event-title'}]")
                    .WithSetting("AutorouteSettings.DefaultPatternIndex", "0")
                )
                .Creatable()
                .Draftable()

                );

            return 1;
        }

        public int UpdateFrom1()
        {
            SchemaBuilder.CreateTable("EventPartRecord", table =>
                table.ContentPartRecord()
                //.Column<DateTime>("EventBegin")
                //.Column<DateTime>("EventEnd")
                .Column<string>("Subtitle")
                );

            ContentDefinitionManager.AlterTypeDefinition("Event", builder =>
                builder.WithPart("EventPart"));
            return 2;
        }
    }
}