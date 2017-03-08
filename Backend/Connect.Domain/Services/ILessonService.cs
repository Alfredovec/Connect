using Connect.Domain.Models;

namespace Connect.Domain.Services
{
    public interface ILessonService
    {
        void Create(Lesson lesson);

        void Update(Lesson lesson);

        Lesson Find(int id);
    }
}
