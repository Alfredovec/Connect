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
    public class UserController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public IHttpActionResult Get(int id)
        {
            var user = _userService.Find(id);
            var userDisplay = _mapper.Map<UserDisplayContract>(user);

            return Ok(userDisplay);
        }
        
        public IHttpActionResult Post(UserUpdateContract user)
        {
            var userDomain = _mapper.Map<User>(user);
            var createdUser = _userService.Create(userDomain);
            var createdUserDisplay = _mapper.Map<UserDisplayContract>(createdUser);

            return Created($"api/users/{createdUserDisplay.Id}", createdUserDisplay);
        }

        public IHttpActionResult Put(int id, UserUpdateContract user)
        {
            var userDomain = _mapper.Map<User>(user);
            var updatedUser = _userService.Update(userDomain);
            var updatedUserDisplay = _mapper.Map<UserDisplayContract>(updatedUser);

            return Ok(updatedUserDisplay);
        }
    }
}
