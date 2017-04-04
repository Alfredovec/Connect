using AutoMapper;
using Connect.Data;
using Connect.Data.Entities;
using Connect.Data.Repositories;
using Connect.Data.Repositories.Interfaces;
using Connect.Domain.Abstract;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class RateService : CrudService<Rate, RateEntity>, IRateService
    {
        /// <inheritdoc />
        public RateService(IRateRepository rateRepository, IMapper mapper) 
            : base(rateRepository, mapper)
        {
        }
    }
}
