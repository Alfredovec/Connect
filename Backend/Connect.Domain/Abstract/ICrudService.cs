namespace Connect.Domain.Abstract
{
    public interface ICrudService<T> : IFind<T>, IUpdate<T>, ICreate<T> { }
}