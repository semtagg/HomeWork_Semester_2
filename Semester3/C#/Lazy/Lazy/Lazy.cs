using System;

namespace Lazy
{
    /// <summary>
    /// A class that implements the ILazy interface in single-threaded mode.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public class Lazy<T> : ILazy<T>
    {
        public Lazy(Func<T> supplier)
        {
            _supplier = supplier;
        }

        private Func<T> _supplier;
        private T _result;
        private bool _isResultCalculated;
        
        public T Get()
        {
            if (!_isResultCalculated)
            {
                _result = _supplier();
                _isResultCalculated = true;
                _supplier = null;

                return _result;
            }

            return _result;
        }
    }
}
