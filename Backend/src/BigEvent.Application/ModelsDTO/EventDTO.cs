using BigEvent.Application.Resources;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BigEvent.Application.ModelsDTO
{
    public class EventDTO
    {

        public int Id { get; set; }

        [Required]
        public string Local { get; set; }

        public string EventDate { get; set; }

        [Required]
        public string Theme { get; set; }

        [Required]
        public int MaximumGuests { get; set; }

        [Required]
        [RegularExpression("(\\([0-9]{2}\\))\\s([9]{1})?([0-9]{4})-([0-9]{4})")]
        public string Phone { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [RegularExpression(@".*\.(gif|jpe?g|bmp|png)$")]
        public string ImageUrl { get; set; }

        public IEnumerable<AllotmentDTO> Allotments { get; set; }

        public IEnumerable<SocialMediaDTO> SocialMedias { get; set; }

        public IEnumerable<SpeakerDTO> Speakers { get; set; }

    }
}
