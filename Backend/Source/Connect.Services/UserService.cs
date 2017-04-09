using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public class UserService : CrudService<User, UserEntity>, IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly ILanguageSkillRepository _languageSkillRepository;
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public UserService(
            IUserRepository userRepository,
            IMapper mapper,
            ILanguageSkillRepository languageSkillRepository)
                : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _languageSkillRepository = languageSkillRepository;
        }

        public void AddToFriends(int firstUserId, int secondUserId)
        {
            var firstUser = _userRepository.Find(firstUserId);
            var secondUser = _userRepository.Find(secondUserId);

            firstUser.Friends.Add(secondUser);
            secondUser.Friends.Add(firstUser);
            _userRepository.Save();
        }

        public IEnumerable<User> GetFriends(int userId)
        {
            var friendsEntities = _userRepository.Get(u => u.Friends.Any(f => f.Id == userId)).ToList();
            var friends = _mapper.Map<IEnumerable<User>>(friendsEntities);

            return friends;
        }

        /// <inheritdoc />
        public IEnumerable<User> GetAll()
        {
            var userEntities = _userRepository.GetAll().ToList();
            var users = _mapper.Map<IEnumerable<User>>(userEntities);

            return users;
        }

        /// <inheritdoc />
        public User AddSkill(int userId, int languageId, string level)
        {
            var skill = _languageSkillRepository
                .Get(s => s.UserId == userId && s.LanguageId == languageId)
                .SingleOrDefault();

            if (skill != null)
                return UpdateSkill(userId, languageId, level);

            var languageSkill = new LanguageSkillEntity
            {
                LanguageId = languageId,
                UserId = userId,
                Level = level
            };

            _languageSkillRepository.Add(languageSkill);
            _languageSkillRepository.Save();

            var userEntity = _userRepository.Find(userId);
            _languageSkillRepository.LoadNavigation(userEntity.Languages);
            var user = _mapper.Map<User>(userEntity);

            return user;
        }

        private User UpdateSkill(int userId, int languageId, string level)
        {
            var skill = _languageSkillRepository
                .Get(s => s.UserId == userId && s.LanguageId == languageId)
                .Single();

            skill.Level = level;
            _languageSkillRepository.Save();

            var userEntity = _userRepository.Find(userId);
            _languageSkillRepository.LoadNavigation(userEntity.Languages);
            var user = _mapper.Map<User>(userEntity);

            return user;
        }
    }
}
