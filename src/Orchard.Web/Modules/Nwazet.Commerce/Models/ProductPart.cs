﻿using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;

namespace Nwazet.Commerce.Models {
    [OrchardFeature("Nwazet.Commerce")]
    public class ProductPart : ContentPart<ProductPartRecord>, IProduct {
        [Required]
        public string Sku {
            get { return Record.Sku; }
            set { Record.Sku = value; }
        }

        [Required]
        public double Price {
            get { return Record.Price; }
            set { Record.Price = value; }
        }
        public bool IsDigital { get { return Record.IsDigital; } set { Record.IsDigital = value; } }
        public double? ShippingCost { get { return Record.ShippingCost; } set { Record.ShippingCost = value; } }
        public double Weight { get { return Record.Weight; } set { Record.Weight = value; } }
        public string Size { get { return Record.Size; } set { Record.Size = value; } }
        public int Inventory { get { return Record.Inventory; } set { Record.Inventory = value; } }
        public string OutOfStockMessage { get { return Record.OutOfStockMessage; } set { Record.OutOfStockMessage = value; } }
        public bool AllowBackOrder { get { return Record.AllowBackOrder; } set { Record.AllowBackOrder = value; } }
    }
}
