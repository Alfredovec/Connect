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
        void AddToFriends(int firstUserId, int secondUserId);

        IEnumerable<User> GetFriends(int userId);

        IEnumerable<User> GetAll();

        User AddSkill(int userId, int languageId, string level);

        IEnumerable<LanguageSkill> GetSkills(int userId);
    }
}
