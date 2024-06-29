using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace WebAPI.Configurations
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig()
        {
            /*CreateMap<AppPeople, PeopleUpdin>();
            CreateMap<PeopleUpdin, AppPeople>();*/

            CreateMap<PeopleUpdin, AppPeople>()
                .ForMember(dest => dest.Id, opt => opt.Ignore())
                .ReverseMap();
        }
    }
}
