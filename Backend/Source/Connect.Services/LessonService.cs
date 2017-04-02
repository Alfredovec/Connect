using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories;
using Connect.Domain.Abstract;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class LessonService : CrudService<Lesson, LessonEntity>, ILessonService
    {
        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
            : base(lessonRepository, mapper)
        { }
    }
}
