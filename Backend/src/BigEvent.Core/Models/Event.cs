using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigEvent.Core.Models
{
    [Table("events")]
    public class Event
    {

        [Column("event_Id")]
        public int Id { get; set; }

        [Column("local")]
        public string Local { get; set; }

        [Column("event_date")]
        public DateTime? EventDate { get; set; } 

        [Column("theme")]
        public string Theme { get; set; }

        [Column("maximum_guests")]
        public int MaximumGuests { get; set; }

        [Column("imageUrl")]
        public string ImageUrl { get; set; }

        [Column("phone_event")]
        public string Phone { get; set; }

        [Column("email_event")]
        public string Email { get; set; }

        public IEnumerable<Allotment> Allotments { get; set; }

        public IEnumerable<SocialMedia> SocialMedias { get; set; }

        public IEnumerable<Speaker> Speakers { get; set; }

        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }

    }
}