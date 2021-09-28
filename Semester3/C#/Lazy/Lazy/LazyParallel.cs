using System;

namespace Lazy
{
    /// <summary>
    /// A class that implements the ILazy interface in multi-threaded mode.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class LazyParallel<T> : ILazy<T>
    {
        public LazyParallel(Func<T> supplier)
        {
            _supplier = supplier;
        }

        private Func<T> _supplier;
        private T _result;
        private bool _isResultCalculated;
        private readonly object _lockObject = new();
        
        public T Get()
        {
            if (!_isResultCalculated)
            {
                lock (_lockObject)
                {
                    if (!_isResultCalculated)
                    {
                        _result = _supplier();
                        _isResultCalculated = true;
                        _supplier = null;
                    }
                }
            }
            
            return _result;
        }
    }
}
