using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using Connect.Api.Models.Display;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TopicController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var result = new TopicDisplayContract { Id = 1, Name = "Music", HasChildren = true };

            return Ok(result);
        }

        [Route("api/topics/{id}/sub")]
        public IHttpActionResult GetSubTopics(int id)
        {
            var result = new List<TopicDisplayContract>
            {
                new TopicDisplayContract { Id = 2, Name = "Folk", HasChildren = false },
                new TopicDisplayContract { Id = 3, Name = "Reggie", HasChildren = false },
                new TopicDisplayContract { Id = 4, Name = "Classic", HasChildren = false }
            };

            return Ok(result);
        }
    }
}




