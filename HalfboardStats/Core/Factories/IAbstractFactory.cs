namespace HalfboardStats.Core.Factories
{
    public interface IAbstractFactory<T>
    {
        T Build();
    }
}