using System;
using System.Collections.Generic;
using System.Linq;
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
            lesson.StartDateTime = lesson.StartDateTime;
            lesson.Duration = lesson.Duration;

            return base.Create(lesson);
        }

        /// <inheritdoc />
        public IEnumerable<Lesson> GetLessons(int userId)
        {
            var lessons = _lessonRepository
                .Get(l => l.UserApprenticeId == userId || l.UserMasterId == userId)
                .ToList();

            var lessonsDomain = _mapper.Map<IEnumerable<Lesson>>(lessons);

            return lessonsDomain;
        }

        /// <inheritdoc />
        public Lesson SetRoom(int lessonId, string roomId)
        {
            var lesson = _lessonRepository.Find(lessonId);
            lesson.RoomId = roomId;
            _lessonRepository.Save();

            var lessonDomain = _mapper.Map<Lesson>(lesson);

            return lessonDomain;
        }
    }
}
