using System.Web.Http;
using Connect.Api.Models.Display;

namespace Connect.Api.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var user = new UserDisplayContract
            {
                Name = "John",
                Surname = "Dou",
                Age = 42
            };

            return Ok(user);
        }

        public IHttpActionResult Put(int id, )
        {
            
        }
    }
}
