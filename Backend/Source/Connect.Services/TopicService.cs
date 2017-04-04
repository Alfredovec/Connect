using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories;
using Connect.Data.Repositories.Interfaces;
using Connect.Domain.Abstract;
using Connect.Domain.Exceptions;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class TopicService : CrudService<Topic, TopicEntity>, ITopicService
    {
        private readonly ITopicRepository _repository;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public TopicService(ITopicRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public IEnumerable<Topic> GetSubTopics(int parentTopicId)
        {
            var subTopicsEntities = _repository.Get(t => t.ParentId == parentTopicId).ToList();
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
            var parentTopicEntity = _repository
                    .Get(t => t.Name == parentTopicName)
                    .SingleOrDefault();
            
            if (parentTopicEntity == null)
                throw new ConnectException($"Topic {parentTopicName} not found");
            
            var topic = new Topic { Name = topicName, ParentId = parentTopicEntity.Id };

            return Create(topic);
        }

        public IEnumerable<Topic> GetRootTopics()
        {
            var rootTopicsEntities = _repository.GetAll().Where(t => t.Parent == null).ToList();
            var rootTopics = _mapper.Map<IEnumerable<Topic>>(rootTopicsEntities);

            return rootTopics;
        }
    }
}
