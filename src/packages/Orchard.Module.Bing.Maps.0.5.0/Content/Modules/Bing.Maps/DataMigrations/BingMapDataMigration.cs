using System.Data;
using Bing.Maps.Models;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.ContentManagement.MetaData;

namespace Bing.Maps.DataMigrations {
    public class BingMapsDataMigration : DataMigrationImpl {

        public int Create() {
            // Creating table BingMapRecord
            SchemaBuilder.CreateTable("BingMapRecord", table => table
                .ContentPartRecord()
                .Column("Latitude", DbType.Single)
                .Column("Longitude", DbType.Single)
                .Column("Width", DbType.Int32)
                .Column("Height", DbType.Int32)
                .Column("Zoom", DbType.Int32)
                .Column("Mode", DbType.String)
            );

            ContentDefinitionManager.AlterPartDefinition(typeof (BingMapPart).Name,
                                                         cfg => cfg.Attachable());

            return 1;
        }

        public int UpdateFrom1() {
            // Create a new widget content type with our map
            ContentDefinitionManager.AlterTypeDefinition("BingMapWidget", cfg => cfg
                .WithPart("BingMapPart")
                .WithPart("WidgetPart")
                .WithPart("CommonPart")
                .WithSetting("Stereotype", "Widget"));

            return 2;
        }
    }
}
