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
        /// <inheritdoc />
        public UserService(IUserRepository repository, IMapper mapper)
            : base(repository, mapper)
        {
        }
    }
}
