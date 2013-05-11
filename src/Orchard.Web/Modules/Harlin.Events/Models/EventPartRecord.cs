using System;
using Orchard.ContentManagement.Records;

namespace Harlin.Events.Models
{
    public class EventPartRecord : ContentPartRecord
    {
        //public virtual DateTime EventBegin { get; set; }
        //public virtual DateTime EventEnd { get; set; }
        public virtual string Subtitle { get; set; }
    }
}