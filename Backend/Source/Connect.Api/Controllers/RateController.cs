using System.Web.Http;
using System.Web.Http.Cors;
using Connect.Api.Models.Display;
using Connect.Api.Models.Update;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    [Route("api/lessons/{id}/rate")]
    public class RateController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var rate = new RateDisplayModel
            {
                Id = 1,
                FromUserId = 1,
                ToUserId = 2,
                LessonId = id,
                Value = 10
            };

            return Ok(rate);
        }
        
        public IHttpActionResult Put(int id, RateUpdateModel rate)
        {
            return Ok();
        }
    }
}
