using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigEvent.Core.Models
{
    [Table("speaker_event")]
    public class SpeakerEvent
    {
        
        // ForeignKey Speaker
        [Column("speaker_id")]
        public int SpeakerId { get; set; }

        public Speaker Speaker { get; set; }


        // ForeignKey Event
        [Column("event_id")]
        public int EventId { get; set; }

        public Event Event { get; set; }

    }
}