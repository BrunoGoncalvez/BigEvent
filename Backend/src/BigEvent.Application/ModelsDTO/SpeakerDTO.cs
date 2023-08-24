using System.Collections.Generic;

namespace BigEvent.Application.ModelsDTO
{
    public class SpeakerDTO
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string ResumeHistory { get; set; }

        public string PhotoUrl { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }

        public IEnumerable<SocialMediaDTO> SocialMedias { get; set; }

        public IEnumerable<SpeakerDTO> Speakers { get; set; }

    }
}
