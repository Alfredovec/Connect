using System.Collections.Generic;
using System.Web.Http;
using System.Web.UI.WebControls;

namespace Connect.Api.Controllers
{
    public class TopicController : ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok(new[] { new { Name = "Movie" }, new { Name = "Song" } });
        }
    }
}




