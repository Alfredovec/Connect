using System.Web.Http;

namespace Connect.Api.Controllers
{
    public class TopicController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new [] { new { Name = "Movie" }, new { Name = "Song" } });
        }
    }
}
