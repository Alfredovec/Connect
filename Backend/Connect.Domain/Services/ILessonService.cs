using System.Collections.Generic;
using Connect.Domain.Abstract;
using Connect.Domain.Models;

namespace Connect.Domain.Services
{
    public interface ILessonService : ICrudService<Lesson>
    {
        IEnumerable<Lesson> GetLessons(int userId);

        Lesson SetRoom(int lessonId, string roomId);
    }
}
