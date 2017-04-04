using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class LanguageController : ApiController
    {
        private readonly ILanguageService _languageService;
        private readonly IMapper _mapper;

        public LanguageController(ILanguageService languageService, IMapper mapper)
        {
            _languageService = languageService;
            _mapper = mapper;
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
    }
}