using Orchard.ContentManagement.Records;

namespace Simian.Framework.Models {
    public class AddressPartRecord : ContentPartRecord {
        public virtual double Latitude { get; set; }
        public virtual double Longitude { get; set; }
        public virtual string City { get; set; }
        public virtual string State { get; set; }
        public virtual string Zipcode { get; set; }
        public virtual string Street { get; set; }
    }
}