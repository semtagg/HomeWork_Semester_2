namespace Lazy.Tests
{
    internal class Lazies
    {
        public static object[] Lazy =
        {
            new object[] { LazyFactory.CreateLazy(() => ++_firstValue), 1 },
            new object[] { LazyFactory.CreateLazy(() => "a"), "a" }
        };
        
        public static object[] LazyParallel =
        {
            new object[] { LazyFactory.CreateParallelLazy(() => ++_secondValue), 1 },
            new object[] { LazyFactory.CreateParallelLazy(() => "a"), "a" }
        };
        
        private static int _firstValue = 0;
        private static int _secondValue = 0;
    }
}
