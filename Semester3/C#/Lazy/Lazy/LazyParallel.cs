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
            => _supplier = supplier ?? throw new ArgumentNullException(nameof(supplier), "Func can't be null.");

        private Func<T> _supplier;
        private T _result;
        private volatile bool _isResultCalculated;
        private readonly object _lockObject = new();
        
        public T Get()
        {
            if (_isResultCalculated)
            {
                return _result;
            }
            
            lock (_lockObject)
            {
                if (_isResultCalculated)
                {
                    return _result;
                }
                    
                _result = _supplier();
                _supplier = null;
                _isResultCalculated = true;
            }

            return _result;
        }
    }
}
