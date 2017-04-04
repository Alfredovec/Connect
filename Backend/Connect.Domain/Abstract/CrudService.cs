using AutoMapper;
using Connect.Data;

namespace Connect.Domain.Abstract
{
    public class CrudService<T, TEntity> : ICrudService<T>
    {
        private readonly IRepository<TEntity> _repository;
        private readonly IMapper _mapper;

        public CrudService(IRepository<TEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
         
        /// <inheritdoc />
        public virtual T Find(int id)
        {
            var entity = _repository.Find(id);
            var domainModel = _mapper.Map<T>(entity);

            return domainModel;
        }

        /// <inheritdoc />
        public virtual T Update(T domainEntity)
        {
            var entity = _mapper.Map<TEntity>(domainEntity);
            _repository.Edit(entity);
            _repository.Save();

            _repository.LoadNavigation(entity);
            var updatedDomainEntity = _mapper.Map<T>(entity);

            return updatedDomainEntity;
        }

        /// <inheritdoc />
        public virtual T Create(T domainEntity)
        {
            var entity = _mapper.Map<TEntity>(domainEntity);
            _repository.Add(entity);
            _repository.Save();

            _repository.LoadNavigation(entity);
            var createdDomainEntity = _mapper.Map<T>(entity);

            return createdDomainEntity;
        }
    }
}