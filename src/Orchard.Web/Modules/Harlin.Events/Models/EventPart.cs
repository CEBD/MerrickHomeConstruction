using System;
using System.ComponentModel.DataAnnotations;
using Orchard.ContentManagement;

namespace Harlin.Events.Models
{
    public class EventPart : ContentPart<EventPartRecord>
    {
        //[Required]
        //public DateTime EventBegin
        //{
        //    get { return Record.EventBegin; }
        //    set { Record.EventBegin = value; }
        //}
        //[Required]
        //public DateTime EventEnd
        //{
        //    get { return Record.EventEnd; }
        //    set { Record.EventEnd = value; }
        //}

        public string Subtitle
        {
            get { return Record.Subtitle; }
            set { Record.Subtitle = value; }
        }

    }
}