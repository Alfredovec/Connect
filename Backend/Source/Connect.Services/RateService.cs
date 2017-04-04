using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Connect.Data.Entities;
using Connect.Data.Repositories.Interfaces;
using Connect.Domain.Abstract;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class RateService : CrudService<Rate, RateEntity>, IRateService
    {
        private readonly IRateRepository _rateRepository;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public RateService(IRateRepository rateRepository, IMapper mapper) 
            : base(rateRepository, mapper)
        {
            _rateRepository = rateRepository;
            _mapper = mapper;
        }

        public IEnumerable<Rate> GetLessonRates(int lessonId)
        {
            var rateEntities = _rateRepository.Get(r => r.LessonId == lessonId).ToList();
            var rates = _mapper.Map<IEnumerable<Rate>>(rateEntities);

            return rates;
        }
        
        public IEnumerable<Rate> GetUserRates(int userId)
        {
            var rateEntities = _rateRepository.Get(r => r.FromUserId == userId || r.ToUserId == userId).ToList();
            var rates = _mapper.Map<IEnumerable<Rate>>(rateEntities);

            return rates;
        }
    }
}
