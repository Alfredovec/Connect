using System.Collections.Generic;
using System.Web.Http;
using System.Web.Http.Cors;
using AutoMapper;
using Connect.Api.Models.Display;
using Connect.Api.Models.Display.Basic;
using Connect.Api.Models.Update;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Api.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class TopicController : ApiController
    {
        private readonly ITopicService _topicService;
        private readonly IMapper _mapper;

        public TopicController(ITopicService topicService, IMapper mapper)
        {
            _topicService = topicService;
            _mapper = mapper;
        }

        [Route("api/topics/root")]
        public IHttpActionResult GetRootTopics()
        {
            var topics = _topicService.GetRootTopics();
            var topicsDisplay = _mapper.Map<IEnumerable<TopicBasicDisplayContract>>(topics);

            return Ok(topicsDisplay);
        }

        public IHttpActionResult Get(int id)
        {
            var topic = _topicService.Find(id);
            var topicDisplay = _mapper.Map<TopicDisplayContract>(topic);

            return Ok(topicDisplay);
        }

        [Route("api/topics/{id}/children")]
        public IHttpActionResult GetSubTopics(int id)
        {
            var topics = _topicService.GetSubTopics(id);
            var topicsDisplay = _mapper.Map<IEnumerable<TopicBasicDisplayContract>>(topics);

            return Ok(topicsDisplay);
        }


        public IHttpActionResult Post(TopicUpdateContract topic)
        {
            var topicDomain = _mapper.Map<Topic>(topic);
            var createdTopic = _topicService.Add(topicDomain);
            var topicDisplay = _mapper.Map<TopicDisplayContract>(createdTopic);

            return Created("", topicDisplay);
        }
    }
}




