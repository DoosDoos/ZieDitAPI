using AutoMapper;
using ZieDitAPI.Dto;
using ZieDitAPI.Models;

namespace ZieDitAPI.Helper
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Event, EventDto>();
            CreateMap<EventDto, Event>();
            CreateMap<Poster, PosterDto>();
            CreateMap<PosterDto, Poster>();
            CreateMap<Presenter, PresenterDto>();
            CreateMap<PresenterDto, Presenter>();
            CreateMap<Visitor, VisitorDto>();
        }
    }
}
