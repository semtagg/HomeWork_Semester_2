using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace HW_5_Task_2.Tests
{
    [TestFixture]
    class FilesManagerTest
    {
        [TestCase]
        public void GetOptimalNetworkTest()
        {
            string[] result =
            {
                "1: 2 (10), 3 (5)"
            };

            FilesManager.GetOptimalNetwork("..\\..\\..\\routers1.txt", "..\\..\\..\\result_routers1.txt");

            var data = File.ReadAllLines("..\\..\\..\\result_routers1.txt");
            Assert.AreEqual(result, data);
        }

        [TestCase]
        public void GetOptimalNetworkErrorTest()
        {
            Assert.Throws<NetworkIsNotConnectedException>(() => FilesManager.GetOptimalNetwork("..\\..\\..\\routers2.txt", "..\\..\\..\\result_routers2.txt"));
        }
    }
}
