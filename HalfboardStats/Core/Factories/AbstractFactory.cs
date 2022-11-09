using System;

namespace HalfboardStats.Core.Factories
{
    public class AbstractFactory<T> : IAbstractFactory<T>
    {
        private readonly Func<T> _factory;

        public AbstractFactory(Func<T> factory)
        {
            _factory = factory;
        }

        public T Build()
        {
            return _factory();
        }
    }
}
