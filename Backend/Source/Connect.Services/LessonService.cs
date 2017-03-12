using System;
using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class LessonService : ILessonService
    {
        private readonly ILessonRepository _lessonRepository;
        private readonly IMapper _mapper;

        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }

        public int Create(Lesson lesson)
        {
            var lessonEntity = _mapper.Map<LessonEntity>(lesson);
            _lessonRepository.Add(lessonEntity);
            _lessonRepository.Save();

            return lessonEntity.Id;
        }

        public void Update(Lesson lesson)
        {
            var lessonEntity = _mapper.Map<LessonEntity>(lesson);
            _lessonRepository.Edit(lessonEntity);
            _lessonRepository.Save();
        }

        public Lesson Find(int id)
        {
            var lessonEntity = _lessonRepository.Find(id);
            var lesson = _mapper.Map<Lesson>(lessonEntity);

            return lesson;
        }
    }
}
