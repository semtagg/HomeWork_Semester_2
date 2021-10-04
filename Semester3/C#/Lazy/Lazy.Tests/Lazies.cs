namespace Lazy.Tests
{
    internal class Lazies
    {
        public static object[] Lazy =
        {
            new object[] { LazyFactory.CreateLazy(() => ++_value1), 1 }
        };
        
        public static object[] LazyParallel =
        {
            new object[] { LazyFactory.CreateParallelLazy(() => ++_value2), 1 }
        };
        
        private static int _value1 = 0;
        private static int _value2 = 0;
    }
}
