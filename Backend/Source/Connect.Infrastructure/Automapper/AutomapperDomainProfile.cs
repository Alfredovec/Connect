using AutoMapper;
using Connect.Data.Entities;
using Connect.Domain.Models;

namespace Connect.Infrastructure.Automapper
{
    public class AutomapperDomainProfile : Profile
    {
        public AutomapperDomainProfile()
        {
            CreateMap<Lesson, LessonEntity>();
            CreateMap<LessonEntity, Lesson>();

            CreateMap<Rate, RateEntity>();
            CreateMap<RateEntity, Rate>();

            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Language, LanguageEntity>().ReverseMap();

            CreateMap<Topic, TopicEntity>();
            CreateMap<TopicEntity, Topic>()
                .PreserveReferences();

            CreateMap<LanguageSkill, LanguageSkillEntity>();
            CreateMap<LanguageSkillEntity, LanguageSkill>();
        }
    }
}
