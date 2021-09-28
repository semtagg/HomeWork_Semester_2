using System;

namespace Lazy
{
    /// <summary>
    /// A class that creates methods of the ILazy interface.
    /// </summary>
    /// <typeparam name="T">Parameter type.</typeparam>
    public static class LazyFactory<T>
    {
        /// <summary>
        /// Creates an instance of the Lazy class.
        /// </summary>
        public static ILazy<T> CreateLazy(Func<T> supplier)
            => new Lazy<T>(supplier);
        
        /// <summary>
        /// Creates an instance of the ParallelLazy class.
        /// </summary>
        public static ILazy<T> CreateParallelLazy(Func<T> supplier)
            => new LazyParallel<T>(supplier);
    }
}
