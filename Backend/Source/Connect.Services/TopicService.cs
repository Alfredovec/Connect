using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories;
using Connect.Domain.Abstract;
using Connect.Domain.Exceptions;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class TopicService : CrudService<Topic, TopicEntity>, ITopicService
    {
        private readonly ITopicRepository _topicRepository;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public TopicService(ITopicRepository topicRepository, IMapper mapper)
            : base(topicRepository, mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public IEnumerable<Topic> GetSubTopics(int parentTopicId)
        {
            var subTopicsEntities = _topicRepository.Get(t => t.ParentId == parentTopicId).ToList();
            var subTopics = _mapper.Map<IEnumerable<Topic>>(subTopicsEntities);

            return subTopics;
        }

        /// <inheritdoc />
        public Topic Create(string topicName, string parentTopicName)
        {
            if (parentTopicName != null)
                return CreateWithParent(topicName, parentTopicName);

            var topic = new Topic { Name = topicName };

            return Create(topic);
        }

        private Topic CreateWithParent(string topicName, string parentTopicName)
        {
            var parentTopicEntity = _topicRepository
                    .Get(t => t.Name == parentTopicName)
                    .SingleOrDefault();
            
            if (parentTopicEntity == null)
                throw new ConnectException($"Topic {parentTopicName} not found");
            
            var topic = new Topic { Name = topicName, ParentId = parentTopicEntity.Id };

            return Create(topic);
        }
    }
}
