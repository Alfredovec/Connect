using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Connect.Api.Models.Display;
using Connect.Api.Models.Update;
using Connect.Domain.Models;
using Connect.Domain.Services;
using Swashbuckle.Swagger.Annotations;

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
            var lessonDisplayContract = _mapper.Map<LessonDisplayContract>(lesson);

            return Ok(lessonDisplayContract);
        }

        public IHttpActionResult Post(LessonUpdateContract lesson)
        {
            var lessonDomain = _mapper.Map<Lesson>(lesson);
            var createdLesson = _lessonService.Create(lessonDomain);

            var lessonDisplayContract = _mapper.Map<LessonDisplayContract>(createdLesson);

            return Created($"api/lessons/{createdLesson.Id}", lessonDisplayContract);
        }
        
        public IHttpActionResult Put(int id, LessonUpdateContract lesson)
        {
            var lessonDomain = _mapper.Map<Lesson>(lesson);
            lessonDomain.Id = id;

            var updatedLesson =_lessonService.Update(lessonDomain);
            var updatedLessonDisplay = _mapper.Map<LessonDisplayContract>(updatedLesson);

            return Ok(updatedLessonDisplay);
        }

        [HttpGet]
        public IHttpActionResult GetByUser([FromUri]int userId)
        {
            var lessons = _lessonService.GetLessons(userId);
            var lessonsDisplayContracts = _mapper.Map<IEnumerable<LessonDisplayContract>>(lessons).ToList();

            return Ok(new
            {
                MasterLessons = lessonsDisplayContracts.Where(l => l.UserMaster.Id == userId),
                ApprenticeLessons = lessonsDisplayContracts.Where(l => l.UserApprentice.Id == userId)
            });
        }

        public IHttpActionResult Put(int lessonId, [FromBody]string roomId)
        {
            var lesson = _lessonService.SetRoom(lessonId, roomId);
            var lessonDisplayContract = _mapper.Map<LessonDisplayContract>(lesson);

            return Ok(lessonDisplayContract);
        }
    }
}
