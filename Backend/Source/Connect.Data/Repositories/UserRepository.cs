using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect.Data.Entities;

namespace Connect.Data.Repositories
{
    public class UserRepository : Repository<UserEntity>, IUserRepository
    {
        /// <inheritdoc />
        public UserRepository(ConnectDbContext context) : base(context)
        {
        }
    }
}
