using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Connect.Api.Models.Display.Basic;
using Connect.Api.Models.Update;
using Connect.Domain.Services;
using Swashbuckle.Swagger.Annotations;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class FriendController : ApiController
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public FriendController(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        [SwaggerOperation(Tags = new[] { "User" })]
        [Route("api/users/{userId}/friends")]
        public IHttpActionResult Post(int userId, UserFriendsUpdateContract friend)
        {
            _userService.AddToFriends(userId, friend.UserId);

            return Ok();
        }

        [Route("api/users/{userId}/friends")]
        [SwaggerOperation(Tags = new[] { "User" })]
        public IHttpActionResult Get(int userId)
        {
            var users = _userService.GetFriends(userId);
            var usersDisplayContracts = _mapper.Map<IEnumerable<UserBasicDisplayContract>>(users);

            return Ok(usersDisplayContracts);
        }
    }
}
