using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace BigEvent.Core.Models
{
    [Table("speakers")]
    public class Speaker
    {
        
        [Column("id_speaker")]
        public int Id { get; set; }

        [Column("name_speaker")]
        public string Name { get; set; }

        [Column("resume_speaker")]
        public string ResumeHistory { get; set; }

        [Column("photo_speaker_url")]
        public string PhotoUrl { get; set; }
        
        [Column("phone_speaker")]
        public string Phone { get; set; }

        [Column("email_speaker")]
        public string Email { get; set; }

        public IEnumerable<SocialMedia> SocialMedias { get; set; }

        public IEnumerable<SpeakerEvent> SpeakerEvents { get; set; }

    }
}