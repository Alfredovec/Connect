using AutoMapper;
using Connect.Data;

namespace Connect.Domain.Abstract
{
    public class CrudService<T, TEntity> : ICrudService<T>
    {
        private readonly IRepository<TEntity> _topicRepository;
        private readonly IMapper _mapper;

        public CrudService(IRepository<TEntity> topicRepository, IMapper mapper)
        {
            _topicRepository = topicRepository;
            _mapper = mapper;
        }

        /// <inheritdoc />
        public virtual T Find(int id)
        {
            var entity = _topicRepository.Find(id);
            var domainModel = _mapper.Map<T>(entity);

            return domainModel;
        }

        /// <inheritdoc />
        public virtual T Update(T domainEntity)
        {
            var entity = _mapper.Map<TEntity>(domainEntity);
            _topicRepository.Edit(entity);
            _topicRepository.Save();

            var updatedDomainEntity = _mapper.Map<T>(entity);

            return updatedDomainEntity;
        }

        /// <inheritdoc />
        public virtual T Create(T domainEntity)
        {
            var entity = _mapper.Map<TEntity>(domainEntity);
            _topicRepository.Add(entity);
            _topicRepository.Save();

            var createdDomainEntity = _mapper.Map<T>(entity);

            return createdDomainEntity;
        }
    }
}