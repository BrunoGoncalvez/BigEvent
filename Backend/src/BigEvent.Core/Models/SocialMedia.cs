using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigEvent.Core.Models
{
    [Table("social_medias")]
    public class SocialMedia
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("name_social_media")]
        public string Name { get; set; }

        [Column("url_social_media")]
        public string URL { get; set; }


        [Column("event_id")]
        public int? EventId { get; set; }

        public Event Event { get; set; }

        [Column("speaker_id")]
        public int? SpeakerId { get; set; }

        public Speaker Speaker { get; set; }

    }
}