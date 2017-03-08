using AutoMapper;
using Connect.Api.Models;
using Connect.Domain.Models;

namespace Connect.Api.Infrastructure.Automapper
{
    public class AutomapperWebProfile : Profile
    {
        public AutomapperWebProfile()
        {
            CreateMap<Lesson, LessonViewModel>().ReverseMap();
        }
    }
}