using Orchard.ContentManagement.Records;

namespace Simian.Properties.Models {
    public class PropertyAddressPartRecord : ContentPartRecord {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zipcode { get; set; }
        public virtual string Street { get; set; }
    }
}