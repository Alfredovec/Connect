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
            CreateMap<TopicUpdateContract, Topic>()
                .ForMember(dest => dest.Parent, opt => opt.MapFrom(src => string.IsNullOrEmpty(src.ParentName) ? null : new Topic { Name = src.ParentName }));

            CreateMap<User, UserDisplayContract>();
            CreateMap<User, UserBasicDisplayContract>();
            CreateMap<UserUpdateContract, User>();

            CreateMap<Language, string>()
                .ConstructUsing(language => language.Name);

            CreateMap<Topic, string>()
                .ConstructUsing(topic => topic.Name);

            CreateMap<LanguageSkill, LanguageSkillBasicDisplayContract>()
                .ForMember(dest => dest.Name, opt => opt.MapFrom(src => src.Language.Name));
        }
    }
}