using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Connect.Api.Models.Display;
using Connect.Api.Models.Update;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
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
            var lessonViewModel = _mapper.Map<LessonDisplayContract>(lesson);

            return Ok(lessonViewModel);
        }

        public IHttpActionResult Post(LessonUpdateContract lesson)
        {
            var lessonDomain = _mapper.Map<Lesson>(lesson);
            var createdLesson = _lessonService.Create(lessonDomain);

            return Created($"api/lessons/{createdLesson.Id}", createdLesson);
        }
        
        public IHttpActionResult Put(int id, LessonUpdateContract lesson)
        {
            var lessonDomain = _mapper.Map<Lesson>(lesson);
            lessonDomain.Id = id;

            var updatedLesson =_lessonService.Update(lessonDomain);
            var updatedLessonDisplay = _mapper.Map<LessonDisplayContract>(updatedLesson);

            return Ok(updatedLessonDisplay);
        }
    }
}
