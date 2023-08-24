using System.Collections.Generic;


namespace BigEvent.Application.ModelsDTO
{
    public class EventDTO
    {

        public int Id { get; set; }

        public string Local { get; set; }

        public string EventDate { get; set; }

        public string Theme { get; set; }

        public int MaximumGuests { get; set; }

        public string ImageUrl { get; set; }

        public string Phone { get; set; }

        public string Email { get; set; }


        public IEnumerable<AllotmentDTO> Allotments { get; set; }

        public IEnumerable<SocialMediaDTO> SocialMedias { get; set; }

        public IEnumerable<SpeakerDTO> Speakers { get; set; }

    }
}
