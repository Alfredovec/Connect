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
        }
    }
}
