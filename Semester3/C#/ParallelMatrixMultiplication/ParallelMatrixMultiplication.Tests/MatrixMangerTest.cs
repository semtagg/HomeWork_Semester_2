using System;
using Microsoft.VisualStudio.TestPlatform.TestHost;
using NUnit.Framework;

namespace ParallelMatrixMultiplication.Tests
{
    public class MatrixMangerTest
    {
        private int[,] firstMatrix;
        private int[,] secondMatrix;
        private int[,] thirdMatrix;
        private int[,] fourthMatrix;
        
        [SetUp]
        public void Setup()
        {
            firstMatrix = MatrixManager.RandomMatrix(100, 100); 
            secondMatrix = MatrixManager.RandomMatrix(100, 100);
            thirdMatrix = MatrixManager.RandomMatrix(1000, 1000);
            fourthMatrix = MatrixManager.RandomMatrix(1000, 1000);
        }

        [Test]
        public void IncorrectMatrixSizesTest()
        {
            Assert.Throws<InvalidMatrixSizeException>(() => MatrixManager.ParallelMatrixMultiplication(firstMatrix, fourthMatrix));
            
            Assert.Throws<InvalidMatrixSizeException>(() => MatrixManager.ParallelMatrixMultiplication(secondMatrix, thirdMatrix));
            
            Assert.DoesNotThrow(() => MatrixManager.ParallelMatrixMultiplication(firstMatrix, secondMatrix));
            
            Assert.DoesNotThrow(() => MatrixManager.ParallelMatrixMultiplication(thirdMatrix, fourthMatrix));
        }

        [Test]
        public void MatrixMultiplyTest()
        {
            var expectedFirstResult = MatrixManager.OrdinaryMatrixMultiplication(firstMatrix, secondMatrix);
            var expectedSecondResult = MatrixManager.OrdinaryMatrixMultiplication(thirdMatrix, fourthMatrix);
            
            var wrongFirstResult = new int[100, 100];
            var wrongSecondResult = new int[1000, 1000];
            
            var firstResult = MatrixManager.ParallelMatrixMultiplication(firstMatrix, secondMatrix);
            var secondResult = MatrixManager.ParallelMatrixMultiplication(thirdMatrix, fourthMatrix);
            
            Assert.IsTrue(FileManagerTest.MatrixAreEqual(firstResult, expectedFirstResult));
            Assert.IsTrue(FileManagerTest.MatrixAreEqual(secondResult, expectedSecondResult));
            
            Assert.IsFalse(FileManagerTest.MatrixAreEqual(firstResult, wrongFirstResult));
            Assert.IsFalse(FileManagerTest.MatrixAreEqual(secondResult, wrongSecondResult));
        }
    }
}
