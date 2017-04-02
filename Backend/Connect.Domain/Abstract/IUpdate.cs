namespace Connect.Domain.Abstract
{
    public interface IUpdate<T>
    {
        T Update(T domainEntity);
    }
}