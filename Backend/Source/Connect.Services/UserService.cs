using System;
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

        /// <inheritdoc />
        public override User Create(User domainEntity)
        {
            var wishedSkills = domainEntity.SkillsWished.ToList();
            domainEntity.SkillsWished = null;

            var userEntity = _mapper.Map<UserEntity>(domainEntity);
            _userRepository.Add(userEntity);
            _userRepository.Save();

            wishedSkills.ForEach(s => s.UserWishedId = userEntity.Id);
            userEntity.SkillsWished = _mapper.Map<ICollection<LanguageSkillEntity>>(wishedSkills);
            _userRepository.Save();

            _userRepository.LoadNavigation(userEntity);
            foreach (var languageSkillEntity in userEntity.SkillsWished)
            {
                _languageSkillRepository.LoadNavigation(languageSkillEntity);
            }
            foreach (var languageSkillEntity in userEntity.Skills)
            {
                _languageSkillRepository.LoadNavigation(languageSkillEntity);
            }
            var createdDomainEntity = _mapper.Map<User>(userEntity);

            return createdDomainEntity;
        }

        /// <inheritdoc />
        public override User Find(int id)
        {
            var userEntity = _userRepository.Find(id);
            var user = _mapper.Map<User>(userEntity);

            foreach (var languageSkill in user.Skills)
            {
                var userLanguageRates = userEntity
                    .IncomingRates
                    .Where(r => r.Lesson.Language.Id == languageSkill.Language.Id)
                    .ToList();

                var masterRates = userLanguageRates.Where(r => r.Lesson.UserMaster == userEntity).ToList();
                var apprenticeRates = userLanguageRates.Where(r => r.Lesson.UserApprentice == userEntity).ToList();

                var masterRate = masterRates.Any() ? masterRates.Average(r => r.Value) : 0;
                var apprenticeRate = apprenticeRates.Any() ? apprenticeRates.Average(r => r.Value) : 0;

                languageSkill.RateMaster = (int)Math.Round(masterRate);
                languageSkill.RateApprentice = (int)Math.Round(apprenticeRate);
            }

            return user;
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
            _languageSkillRepository.LoadNavigation(userEntity.Skills);
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
            _languageSkillRepository.LoadNavigation(userEntity.Skills);
            var user = _mapper.Map<User>(userEntity);

            return user;
        }

        public IEnumerable<LanguageSkill> GetSkills(int userId)
        {
            var user = _userRepository.Find(userId);
            var languageSkillEntities = user.Skills.ToList();

            var languageSkills = _mapper.Map<IEnumerable<LanguageSkill>>(languageSkillEntities);

            return languageSkills;
        }

        /// <inheritdoc />
        public IEnumerable<User> Search(int userId, int languageId, string level)
        {
            var user = _userRepository.Find(userId);
            char levelLetter;
            switch (level.ToLower())
            {
                case "basic":
                    levelLetter = 'A';
                    break;
                case "intermediate":
                    levelLetter = 'B';
                    break;
                case "advanced":
                    levelLetter = 'C';
                    break;
                default:
                    throw new Exception("Unknown level");
            }

            var userEntities = 
                _userRepository
                    .GetAll()
                    .ToList()
                    .Where(u => u.Skills.Any(s => s.LanguageId == languageId && s.Level[0] == levelLetter))
                    .Where(u => u.SkillsWished.Select(s => s.LanguageId).Intersect(user.Skills.Select(s => s.LanguageId)).Any())
                    .ToList();

            var users = _mapper.Map<IEnumerable<User>>(userEntities);

            return users;
        }
    }
}
