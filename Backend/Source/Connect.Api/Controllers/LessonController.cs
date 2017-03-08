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

        public IHttpActionResult Post(LessonViewModel lesson)
        {
            var lessonDomain = _mapper.Map<Lesson>(lesson);
            _lessonService.Create(lessonDomain);

            return Ok();
        }

        public IHttpActionResult Put(int id, LessonViewModel lesson)
        {
            var lessonDomain = _mapper.Map<Lesson>(lesson);
            lesson.Id = id;
            _lessonService.Update(lessonDomain);

            return Ok();
        }
    }
}
