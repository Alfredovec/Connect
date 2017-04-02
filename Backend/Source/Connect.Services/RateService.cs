using AutoMapper;
using Connect.Data;
using Connect.Data.Entities;
using Connect.Domain.Abstract;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class RateService : CrudService<Rate, RateEntity>, IRateService
    {
        /// <inheritdoc />
        public RateService(IRepository<RateEntity> topicRepository, IMapper mapper) 
            : base(topicRepository, mapper)
        {
        }
    }
}
