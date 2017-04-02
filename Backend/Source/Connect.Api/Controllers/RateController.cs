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
    [Route("api/lessons/{id}/rate")]
    public class RateController : ApiController
    {
        private readonly IRateService _rateService;
        private readonly IMapper _mapper;

        public RateController(IRateService rateService, IMapper mapper)
        {
            _rateService = rateService;
            _mapper = mapper;
        }

        public IHttpActionResult Get(int id)
        {
            var rate = _rateService.Find(id);
            var rateDisplay = _mapper.Map<RateDisplayContract>(rate);

            return Ok(rateDisplay);
        }
        
        public IHttpActionResult Post(RateUpdateContract rate)
        {
            var rateDomain = _mapper.Map<Rate>(rate);
            var createdRate = _rateService.Create(rateDomain);
            var createdRateDisplay = _mapper.Map<RateDisplayContract>(createdRate);

            return Ok(createdRateDisplay);
        }
    }
}
