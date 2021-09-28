using System;
using System.Collections;
using System.Threading;
using NUnit.Framework;

namespace Lazy.Tests
{
    public class LazyTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void SimpleLazyTest()
        {
            var intLazy = LazyFactory<int>.CreateLazy(() => 1);
            var stringLazy = LazyFactory<string>.CreateLazy(() => "a");
            
            for (var i = 0; i < 10; i++)
            {
                Assert.AreEqual(1, intLazy.Get());
                Assert.AreEqual("a", stringLazy.Get());
            }
        }

        [Test]
        public void SimpleLazyParallelTest()
        {
            var intLazy = LazyFactory<int>.CreateParallelLazy(() => 1);
            var stringLazy = LazyFactory<string>.CreateParallelLazy(() => "a");
            
            for (var i = 0; i < 10; i++)
            {
                Assert.AreEqual(1, intLazy.Get());
                Assert.AreEqual("a", stringLazy.Get());
            }
        }

        [Test]
        public void SupplierCanBeNullTest()
        {
            var nullLazy = LazyFactory<string>.CreateLazy(() => null);
            var nullParallelLazy = LazyFactory<string>.CreateParallelLazy(() => null);
            
            for (var i = 0; i < 10; i++)
            {
                Assert.AreEqual(null, nullLazy.Get());
                Assert.AreEqual(null, nullParallelLazy.Get());
            }
        }

        [Test]
        public void RacesForParallelLazyTest()
        {
            var count = 0;
            var result = LazyFactory<int>.CreateParallelLazy(() => Interlocked.Increment(ref count));
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
