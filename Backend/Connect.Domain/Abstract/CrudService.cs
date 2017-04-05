using AutoMapper;
using Connect.Data;

namespace Connect.Domain.Abstract
{
    public class CrudService<T, TEntity> : ICrudService<T>
    {
        private readonly IRepository<TEntity> _userRepository;
        private readonly IMapper _mapper;

        public CrudService(IRepository<TEntity> userRepository, IMapper mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }
         
        /// <inheritdoc />
        public virtual T Find(int id)
        {
            var entity = _userRepository.Find(id);
            var domainModel = _mapper.Map<T>(entity);

            return domainModel;
        }

        /// <inheritdoc />
        public virtual T Update(T domainEntity)
        {
            var entity = _mapper.Map<TEntity>(domainEntity);
            _userRepository.Edit(entity);
            _userRepository.Save();

            _userRepository.LoadNavigation(entity);
            var updatedDomainEntity = _mapper.Map<T>(entity);

            return updatedDomainEntity;
        }

        /// <inheritdoc />
        public virtual T Create(T domainEntity)
        {
            var entity = _mapper.Map<TEntity>(domainEntity);
            _userRepository.Add(entity);
            _userRepository.Save();

            _userRepository.LoadNavigation(entity);
            var createdDomainEntity = _mapper.Map<T>(entity);

            return createdDomainEntity;
        }
    }
}