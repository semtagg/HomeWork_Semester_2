namespace Lazy.Tests
{
    internal class Lazies
    {
        public static object[] Lazy =
        {
            new object[] { LazyFactory.CreateLazy(() => _value++), 1 }
        };
        
        public static object[] LazyParallel =
        {
            new object[] { LazyFactory.CreateParallelLazy(() => ++_value), 1 }
        };
        
        private static int _value = 0;
    }
}
