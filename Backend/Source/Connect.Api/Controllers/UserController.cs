using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;
using Connect.Api.Models.Display;
using Connect.Api.Models.Update;
using Swashbuckle.Swagger;
using Swashbuckle.Swagger.Annotations;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class UserController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var user = new UserDisplayContract
            {
                Name = "John",
                Surname = "Dou",
                AvatarUrl = $"/avatars/{id}"
            };

            return Ok(user);
        }
        
        public IHttpActionResult Post(UserUpdateContract user)
        {
            var userDisplay = new UserDisplayContract
            {
                Id = 101,
                Name = user.Name,
                Surname = user.Surname,
                AvatarUrl = null
            };

            return Created($"api/users/{userDisplay.Id}", userDisplay);
        }

        public IHttpActionResult Put(int id, UserUpdateContract user)
        {
            return Ok();
        }
    }
}
