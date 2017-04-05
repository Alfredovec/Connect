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
        private readonly IMapper _mapper;

        /// <inheritdoc />
        public UserService(IUserRepository userRepository, IMapper mapper)
            : base(userRepository, mapper)
        {
            _userRepository = userRepository;
            _mapper = mapper;
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
    }
}
