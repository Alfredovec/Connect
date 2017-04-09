using AutoMapper;
using Connect.Data.Entities;
using Connect.Domain.Models;

namespace Connect.Infrastructure.Automapper
{
    public class AutomapperDomainProfile : Profile
    {
        public AutomapperDomainProfile()
        {
            CreateMap<Lesson, LessonEntity>().ReverseMap();
            CreateMap<Rate, RateEntity>().ReverseMap();

            CreateMap<User, UserEntity>().ReverseMap();
            CreateMap<Language, LanguageEntity>().ReverseMap();

            CreateMap<Topic, TopicEntity>();
            CreateMap<TopicEntity, Topic>()
                .PreserveReferences();

            CreateMap<LanguageSkill, LanguageSkillEntity>();
            CreateMap<LanguageSkillEntity, LanguageSkill>()
                .ForMember(dest => dest.User, opt => opt.Ignore());
        }
    }
}
