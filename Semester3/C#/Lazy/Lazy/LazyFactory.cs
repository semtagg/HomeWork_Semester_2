using System;

namespace Lazy
{
    public static class LazyFactory<T>
    {
        public static ILazy<T> CreateLazy(Func<T> supplier)
            => new Lazy<T>(supplier);
        
        public static ILazy<T> CreateParallelLazy(Func<T> supplier)
            => new LazyParallel<T>(supplier);
    }
}
