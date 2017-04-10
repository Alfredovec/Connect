using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories.Interfaces;
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
        public Topic Add(Topic topic)
        {
            if (topic.Parent != null)
                return CreateWithParent(topic);

            return Create(topic);
        }

        private Topic CreateWithParent(Topic topic)
        {
            var parentTopicEntity = _topicRepository
                    .Get(t => t.Name == topic.Parent.Name)
                    .SingleOrDefault();
            
            if (parentTopicEntity == null)
                throw new ConnectException($"Topic {topic.Parent.Name} not found");

            topic.ParentId = parentTopicEntity.Id;

            return Create(topic);
        }

        public IEnumerable<Topic> GetRootTopics()
        {
            var rootTopicsEntities = _topicRepository.GetAll().Where(t => t.Parent == null).ToList();
            var rootTopics = _mapper.Map<IEnumerable<Topic>>(rootTopicsEntities);

            return rootTopics;
        }
    }
}
