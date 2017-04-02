using AutoMapper;
using Connect.Api.Models.Display;
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
        }
    }
}