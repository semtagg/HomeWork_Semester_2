using System.IO;
using NUnit.Framework;

namespace ParallelMatrixMultiplication.Tests
{
    public class FileManagerTest
    {
        public static bool MatrixAreEqual(int[,] m1, int[,] m2)
        {
            for (var i = 0; i < m1.GetLength(0); i++)
            {
                for (var j = 0; j < m1.GetLength(1); j++)
                {
                    if (m1[i, j] != m2[i, j])
                        return false;
                }
            }
            
            return true;
        }
        
        [Test]
        public void FileDoesNotExistTest()
        {
            Assert.Throws<FileNotFoundException>(() => FileManager.ReadMatrixFromFile("path.txt"));
        }

        [Test]
        public void FilesExistTest()
        {
            var expectedFirstMatrix = new int[3, 3]
            {
                { 1, 2, 3 },
                { 4, 5, 6 },
                { 7, 8, 9 }
            };
            var firstMatrix = FileManager.ReadMatrixFromFile("..\\..\\..\\matrix1.txt");
            Assert.IsTrue(MatrixAreEqual(firstMatrix, expectedFirstMatrix));
            
            var expectedSecondMatrix = new int[3, 3]
            {
                { 9, 8, 7 },
                { 6, 5, 4 },
                { 3, 2, 1 }
            };
            var secondMatrix = FileManager.ReadMatrixFromFile("..\\..\\..\\matrix2.txt");
            Assert.IsTrue(MatrixAreEqual(secondMatrix, expectedSecondMatrix));
        }

        [Test]
        public void WriteToFileTest()
        {
            var expectedMatrix = new int[2, 2]
            {
                {1, 2},
                {3, 4}
            };
            
            FileManager.WriteMatrixToFile(expectedMatrix, "hello.txt");
            var matrix = FileManager.ReadMatrixFromFile("hello.txt");
            Assert.IsTrue(MatrixAreEqual(matrix, expectedMatrix));
        }
        
    }
}
