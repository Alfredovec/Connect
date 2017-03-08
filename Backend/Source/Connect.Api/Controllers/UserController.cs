using System.Web.Http;
using Connect.Api.Models;

namespace Connect.Api.Controllers
{
    public class UserController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var user = new UserViewModel
            {
                Name = "John",
                Surname = "Dou",
                Age = 42
            };

            return Ok(user);
        }
    }
}
