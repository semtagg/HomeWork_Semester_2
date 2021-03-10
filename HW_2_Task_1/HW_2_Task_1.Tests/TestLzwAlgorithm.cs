using NUnit.Framework;
using System.IO;

namespace HW_2_Task_1
{
    [TestFixture]
    class TestLzwAlgorithm
    {
        private static bool IsEqual(string readFilePath, string writeFilePath)
        {
            using FileStream readFile = File.OpenRead(readFilePath);
            using FileStream writeFile = File.OpenRead(writeFilePath);
            if (writeFile.Length != readFile.Length)
            {
                return false;
            }
            for (int i = 0; i < readFile.Length; i++)
            {
                if (readFile.ReadByte() != writeFile.ReadByte())
                {
                    return false;
                }
            }
            return true;
        }

        [TestCase]
        public void CompressAndDecompressTxt()
        {
            var readFilePath = "../testTxtAfter.txt";
            var writeFilePath = "../testTxtBefore.txt";
            LzwAlgorithm.Compress(readFilePath);
            File.Delete(readFilePath);
            LzwAlgorithm.Decompress(readFilePath + ".zipped");
            Assert.IsTrue(IsEqual(readFilePath, writeFilePath));
            File.Delete(readFilePath + ".zipped");
        }

        [TestCase]
        public void CompressAndDecompressBmp()
        {
            var readFilePath = "../testBmpAfter.bmp";
            var writeFilePath = "../testBmpBefore.bmp";
            LzwAlgorithm.Compress(readFilePath);
            File.Delete(readFilePath);
            LzwAlgorithm.Decompress(readFilePath + ".zipped");
            Assert.IsTrue(IsEqual(readFilePath, writeFilePath));
            File.Delete(readFilePath + ".zipped");
        }
    }
}
