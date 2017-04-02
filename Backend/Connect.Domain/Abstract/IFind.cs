namespace Connect.Domain.Abstract
{
    public interface IFind<out T>
    {
        T Find(int id);
    }
}
