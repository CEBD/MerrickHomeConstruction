using Orchard.ContentManagement;

namespace Simian.Framework.Models {
    public class AddressPart : ContentPart<AddressPartRecord> {
        public double Latitude
        {
            get { return Record.Latitude; }
            set { Record.Latitude = value; }
        }

        public double Longitude
        {
            get { return Record.Longitude; }
            set { Record.Longitude = value; }
        }

        public string City {
            get { return Record.City; }
            set { Record.City = value; }
        }

        public string State
        {
            get { return Record.State; }
            set { Record.State = value; }
        }

        public string Zipcode
        {
            get { return Record.Zipcode; }
            set { Record.Zipcode = value; }
        }

        public string Street
        {
            get { return Record.Street; }
            set { Record.Street = value; }
        }
    }
}