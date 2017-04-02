namespace Connect.Domain.Abstract
{
    public interface ICreate<T>
    {
        T Create(T entity);
    }
}