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
            CreateMap<Lesson, LessonDisplayContract>().ReverseMap();
            CreateMap<Lesson, LessonUpdateContract>().ReverseMap();
        }
    }
}