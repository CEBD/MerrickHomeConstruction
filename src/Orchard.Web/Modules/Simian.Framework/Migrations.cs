using System;
using System.Collections.Generic;
using System.Data;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.MetaData;
using Orchard.ContentManagement.MetaData.Builders;
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

            return 1;
        }
    }
}