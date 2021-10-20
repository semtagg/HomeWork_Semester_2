using System;

namespace Lazy
{
    /// <summary>
    /// A class that creates methods of the ILazy interface.
    /// </summary>
    public static class LazyFactory
    {
        /// <summary>
        /// Creates an instance of the Lazy class.
        /// </summary>
        public static ILazy<T> CreateLazy<T>(Func<T> supplier)
            => new Lazy<T>(supplier);
        
        /// <summary>
        /// Creates an instance of the ParallelLazy class.
        /// </summary>
        public static ILazy<T> CreateParallelLazy<T>(Func<T> supplier)
            => new LazyParallel<T>(supplier);
    }
}
