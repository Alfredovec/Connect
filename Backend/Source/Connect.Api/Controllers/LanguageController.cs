using System.Collections.Generic;
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
        
        public IHttpActionResult Get()
        {
            var languages = _languageService.GetAll();
            var languagesDisplay = _mapper.Map<IEnumerable<LanguageDisplayContract>>(languages);

            return Ok(languagesDisplay);
        }

        public IHttpActionResult Get(int id)
        {
            var language = _languageService.Find(id);
            var languageDisplay = _mapper.Map<LanguageDisplayContract>(language);

            return Ok(languageDisplay);
        }

        [Route("api/topics/simpliest")]
        public IHttpActionResult GetSimpliestLanguages()
        {
            var languages = _languageService.GetSimpliestLanguages();
            var languagesDisplay = _mapper.Map<IEnumerable<LanguageDisplayContract>>(languages);

            return Ok(languagesDisplay);
        }

        public IHttpActionResult Post(LanguageUpdateContract language)
        {
            var languageDomain = _mapper.Map<Language>(language);
            var createdLanguage = _languageService.Create(languageDomain);
            var languageDisplay = _mapper.Map<LanguageDisplayContract>(createdLanguage);

            return Created("", languageDisplay);
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
            var userDisplay = _mapper.Map<IEnumerable<LanguageSkillDisplayContract>>(user);

            return Ok(userDisplay);
        }
    }
}