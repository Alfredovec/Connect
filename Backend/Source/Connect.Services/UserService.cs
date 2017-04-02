using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Connect.Data;
using Connect.Data.Entities;
using Connect.Domain.Abstract;
using Connect.Domain.Models;
using Connect.Domain.Services;

namespace Connect.Services
{
    public class UserService : CrudService<User, UserEntity>, IUserService
    {
        /// <inheritdoc />
        public UserService(IRepository<UserEntity> topicRepository, IMapper mapper) 
            : base(topicRepository, mapper)
        {
        }
    }
}
