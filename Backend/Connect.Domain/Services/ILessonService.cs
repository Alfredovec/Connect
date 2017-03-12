using Connect.Domain.Models;

namespace Connect.Domain.Services
{
    public interface ILessonService
    {
        int Create(Lesson lesson);

        void Update(Lesson lesson);

        Lesson Find(int id);
    }
}
