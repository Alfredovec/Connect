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
    public class RateController : ApiController
    {
        private readonly IRateService _rateService;
        private readonly IMapper _mapper;

        public RateController(IRateService rateService, IMapper mapper)
        {
            _rateService = rateService;
            _mapper = mapper;
        }

        [Route("api/lessons/{lessonId}/rates")]
        public IHttpActionResult GetLessonRates(int lessonId)
        {
            var rates = _rateService.GetLessonRates(lessonId);
            var ratesDisplay = _mapper.Map<IEnumerable<RateDisplayContract>>(rates);

            return Ok(ratesDisplay);
        }

        [Route("api/users/{userId}/rates")]
        public IHttpActionResult GetUserRates(int userId)
        {
            var rates = _rateService.GetUserRates(userId);
            var ratesDisplay = _mapper.Map<IEnumerable<RateDisplayContract>>(rates).ToList();
            
            var displayModel = new
            {
                OutcomingRates = ratesDisplay.Where(r => r.FromUserId == userId),
                IncomingRates = ratesDisplay.Where(r => r.ToUserId == userId),
            };

            return Ok(displayModel);
        }

        [Route("api/lessons/{lessonId}/rates")]
        public IHttpActionResult Put(int lessonId, RateUpdateContract rate)
        {
            var rateDomain = _mapper.Map<Rate>(rate);
            rate.LessonId = lessonId;

            var createdRate = _rateService.Create(rateDomain);
            var createdRateDisplay = _mapper.Map<RateDisplayContract>(createdRate);

            return Created("", createdRateDisplay);
        }
    }
}
