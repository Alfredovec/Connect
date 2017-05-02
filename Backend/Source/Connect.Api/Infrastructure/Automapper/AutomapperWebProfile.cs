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
            CreateMap<TopicUpdateContract, Topic>();

            CreateMap<User, UserDisplayContract>();
            CreateMap<User, UserBasicDisplayContract>();
            CreateMap<UserUpdateContract, User>();

            CreateMap<LanguageUpdateContract, Language>();
            CreateMap<Language, LanguageDisplayContract>();
            CreateMap<Language, string>()
                .ConstructUsing(language => language.Name);
            
            CreateMap<Topic, string>()
                .ConstructUsing(topic => topic.Name);

            CreateMap<LanguageSkill, LanguageSkillDisplayContract>();
            CreateMap<LanguageSkillUpdateContract, LanguageSkill>();
        }
    }
}