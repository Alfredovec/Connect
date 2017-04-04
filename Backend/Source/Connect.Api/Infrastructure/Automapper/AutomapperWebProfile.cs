using AutoMapper;
using Connect.Api.Models.Display;
using Connect.Api.Models.Display.Basic;
using Connect.Api.Models.Update;
using Connect.Domain.Models;

namespace Connect.Api.Infrastructure.Automapper
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Lesson, LessonDisplayContract>();
            CreateMap<LessonUpdateContract, Lesson>();

            CreateMap<Rate, RateDisplayContract>().ReverseMap();
            CreateMap<RateUpdateContract, Rate>();

            CreateMap<Topic, TopicDisplayContract>();
            CreateMap<Topic, TopicBasicDisplayContract>();

            CreateMap<User, UserDisplayContract>();
            CreateMap<UserUpdateContract, User>();

            CreateMap<User, UserBasicDisplayContract>()
                .ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.Surname == null ? src.Name : $"{src.Name} {src.Surname}"));

            CreateMap<Language, string>()
                .ConstructUsing(language => language.Name);

            CreateMap<Topic, string>()
                .ConstructUsing(topic => topic.Name);
        }
    }
}