using System.Collections.Generic;
using Connect.Domain.Abstract;
using Connect.Domain.Models;

namespace Connect.Domain.Services
{
    public interface IRateService : ICrudService<Rate>
    {
        IEnumerable<Rate> GetLessonRates(int lessonId);

        IEnumerable<Rate> GetUserRates(int userId);
    }
}
