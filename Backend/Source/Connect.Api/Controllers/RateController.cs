using System.Web.Http;

namespace Connect.Api.Controllers
{
    public class RateController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new { RatesCount = 100 });
        }
    }
}
