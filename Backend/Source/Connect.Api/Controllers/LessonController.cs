using System;
using System.Web.Http;
using System.Web.Http.Results;
using AutoMapper;
using Connect.Api.Models;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Api.Controllers
{
    public class LessonController : ApiController
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }

        public IHttpActionResult Get(int id)
        {
            var lesson = _lessonService.Find(id);
            var lessonViewModel = _mapper.Map<LessonViewModel>(lesson);

            return Ok(lessonViewModel);
        }

        public IHttpActionResult Post(LessonViewModel lessonViewModel)
        {
            var lesson = _mapper.Map<Lesson>(lessonViewModel);
            _lessonService.Create(lesson);

            return Ok();
        }

        public IHttpActionResult Put(int id, LessonViewModel lessonViewModel)
        {
            var lesson = _mapper.Map<Lesson>(lessonViewModel);
            lesson.Id = id;
            _lessonService.Update(lesson);

            return Ok();
        }
    }
}
