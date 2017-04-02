using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Connect.Domain.Abstract;
using Connect.Domain.Models;

namespace Connect.Domain.Services
{
    public interface IUserService : ICrudService<User>
    {
    }
}
