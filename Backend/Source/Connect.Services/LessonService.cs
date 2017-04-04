using System;
using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories.Interfaces;
using Connect.Domain.Abstract;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class LessonService : CrudService<Lesson, LessonEntity>, ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
            : base(lessonRepository, mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public override Lesson Create(Lesson lesson)
        {
            lesson.StartDateTime = DateTimeOffset.UtcNow.AddHours(1);
            lesson.FinishDateTime = DateTimeOffset.UtcNow.AddHours(2);

            return base.Create(lesson);
        }
    }
}
