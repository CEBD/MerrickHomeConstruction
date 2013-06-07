using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Records;

namespace Bing.Maps.Models {
    public class BingMapRecord: ContentPartRecord {
        public virtual float Latitude { get; set;}
        public virtual float Longitude { get; set;}

        public virtual int Width { get; set; }
        public virtual int Height { get; set; }
        public virtual int Zoom { get; set; }
        [StringLength(20)]
        public virtual string Mode { get; set; }
    }

    public class BingMapPart : ContentPart<BingMapRecord> {
        [Required]
        public float Latitude {
            get { return Record.Latitude; }
            set { Record.Latitude = value; }
        }

        [Required]
        public float Longitude {
            get { return Record.Longitude; }
            set { Record.Longitude = value; }
        }

        [Required]
        public int Width {
            get { return Record.Width; }
            set { Record.Width = value; }
        }

        [Required]
        public int Height {
            get { return Record.Height; }
            set { Record.Height = value; }
        }

        [Required]
        public int Zoom {
            get { return Record.Zoom; }
            set { Record.Zoom = value; }
        }

        [Required]
        public string Mode {
            get { return Record.Mode; }
            set { Record.Mode = value; }
        }
    }
}
