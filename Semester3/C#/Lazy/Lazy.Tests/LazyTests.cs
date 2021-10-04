using System;
using System.Threading;
using NUnit.Framework;

namespace Lazy.Tests
{
    public class LazyTests
    {
        [TestCaseSource(typeof(Lazies), nameof(Lazies.Lazy))]
        public void SimpleLazyTest<T>(Lazy<T> lazy, T expectedValue)
        {
            for (var i = 0; i < 10; i++)
            {
                var value = lazy.Get();
                Assert.AreEqual(expectedValue, value);
            }
        }

        [TestCaseSource(typeof(Lazies), nameof(Lazies.LazyParallel))]
        public void SimpleLazyParallelTest<T>(LazyParallel<T> lazy, T expectedValue)
        {
            for (var i = 0; i < 10; i++)
            {
                var value = lazy.Get();
                Assert.AreEqual(expectedValue, value);
            }
        }

        [Test]
        public void SupplierCannotBeNullTest()
        {
            Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateLazy<string>(null));
            Assert.Throws<ArgumentNullException>(() => LazyFactory.CreateParallelLazy<string>(null));
        }

        [Test]
        public void RacesForParallelLazyTest()
        {
            var count = 0;
            var result = LazyFactory.CreateParallelLazy(() => Interlocked.Increment(ref count));
            var threads = new Thread[Environment.ProcessorCount];
            for (var index = 0; index < threads.Length; index++)
            {
                threads[index] = new Thread(() =>
                {
                    for (var i = 0; i < 1000; i++)
                    {
                        Assert.AreEqual(1, result.Get());
                    }
                });
            }

            foreach (var thread in threads)
            {
                thread.Start();
            }

            foreach (var thread in threads)
            {
                thread.Join();
            }
        }
    }
}
