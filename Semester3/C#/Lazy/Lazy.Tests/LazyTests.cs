using System;
using System.Collections.Generic;
using System.Threading;
using NUnit.Framework;

namespace Lazy.Tests
{
    public class LazyTests
    {
        [TestCaseSource(nameof(Lazies))]
        public void SimpleLazyTest(Func<Func<int>, ILazy<int>> lazies)
        {
            var value = 0;
            var lazy = lazies(() => ++value);
            
            for (var i = 0; i < 10; i++)
            {
                var result = lazy.Get();
                Assert.AreEqual(1, result);
            }
        }

        [TestCaseSource(nameof(Lazies))]
        public void SupplierCannotBeNullTest(Func<Func<int>, ILazy<int>> lazies)
        {
            Assert.Throws<ArgumentNullException>(() => lazies(null));
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
        
        private static IEnumerable<Func<Func<int>, ILazy<int>>> Lazies()
        {
            yield return LazyFactory.CreateLazy;
            yield return LazyFactory.CreateParallelLazy;
        }
    }
}
