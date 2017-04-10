using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Connect.Api.Models.Display;
using Connect.Api.Models.Display.Basic;
using Connect.Api.Models.Update;
using Connect.Domain.Models;
using Connect.Domain.Services;
using Swashbuckle.Swagger.Annotations;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LanguageController : ApiController
    {
        private readonly ILanguageService _languageService;
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper, IUserService userService)
        {
            _languageService = languageService;
            _mapper = mapper;
            _userService = userService;
        }

        [Route("api/languages/all")]
        public IHttpActionResult GetList()
        {
            var languages = _languageService.GetAll();
            var languagesDisplay = _mapper.Map<IEnumerable<string>>(languages);

            return Ok(languagesDisplay);
        }

        public IHttpActionResult Get(int id)
        {
            var language = _languageService.Find(id);

            return Ok(language);
        }

        public IHttpActionResult Post(string name)
        {
            var language = _languageService.Create(new Language { Name = name });

            return Created("", language);
        }

        [Route("api/users/{userId}/skills")]
        [SwaggerOperation(Tags = new[] { "User" })]
        public IHttpActionResult PutSkills(int userId, LanguageSkillUpdateContract skill)
        {
            var user = _userService.AddSkill(userId, skill.LanguageId, skill.Level);
            var userDisplay = _mapper.Map<UserDisplayContract>(user);

            return Ok(userDisplay);
        }

        [Route("api/users/{userId}/skills")]
        [SwaggerOperation(Tags = new[] { "User" })]
        public IHttpActionResult GetSkills(int userId)
        {
            var user = _userService.GetSkills(userId);
            var userDisplay = _mapper.Map<IEnumerable<LanguageSkillBasicDisplayContract>>(user);

            return Ok(userDisplay);
        }
    }
}