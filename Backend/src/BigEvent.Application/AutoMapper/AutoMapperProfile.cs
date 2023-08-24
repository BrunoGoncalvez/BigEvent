using AutoMapper;
using BigEvent.Application.ModelsDTO;
using BigEvent.Core.Models;

namespace BigEvent.Application.AutoMapper
{
    public class AutoMapperProfile : Profile
    {

        public AutoMapperProfile()
        {

            CreateMap<Allotment, AllotmentDTO>().ReverseMap();
            CreateMap<Event, EventDTO>().ReverseMap();
            CreateMap<SocialMedia, SocialMediaDTO>().ReverseMap();
            CreateMap<Speaker, SpeakerDTO>().ReverseMap();

        }

    }
}
