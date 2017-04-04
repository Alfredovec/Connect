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
    public class LanguageService : CrudService<Language, LanguageEntity>, ILanguageService
    {
        private readonly ILanguageRepository _languageRepository;
        private readonly IMapper _mapper;

        public LanguageService(ILanguageRepository languageRepository, IMapper mapper) : base(languageRepository, mapper)
        {
            _languageRepository = languageRepository;
            _mapper = mapper;
        }

        public IEnumerable<Language> GetAll()
        {
            var languageEntities = _languageRepository.GetAll().ToList();
            var languages = _mapper.Map<IEnumerable<Language>>(languageEntities);

            return languages;
        }
    }
}
