using System;
using NUnit.Framework;

namespace ParallelMatrixMultiplication.Tests
{
    public class MatrixMangerTest
    {
        private int[,] RandomMatrix(int rowNumber, int columnNumber)
        {
            var matrix = new int[rowNumber, columnNumber];
            for (var i = 0; i < rowNumber; i++)
            {
                for (var j = 0; j < columnNumber; j++)
                {
                    matrix[i, j] = new Random().Next() % 100;
                }    
            }

            return matrix;
        }

        private int[,] OrdinaryMatrixMultiplication(int[,] m1, int[,] m2)
        {
            var result = new int[m1.GetLength(0), m2.GetLength(1)];
            for (var i = 0; i < m1.GetLength(0); i++)
            {
                for (var j = 0; j < m2.GetLength(1); j++)
                {
                    for (var k = 0; k < m2.GetLength(0); k++)
                    {
                        result[i,j] += m1[i,k] * m2[k,j];
                    }
                }
            }

            return result;
        }
        
        private int[,] firstMatrix;
        private int[,] secondMatrix;
        private int[,] thirdMatrix;
        private int[,] fourthMatrix;
        
        [SetUp]
        public void Setup()
        {
            firstMatrix = RandomMatrix(100, 100); 
            secondMatrix = RandomMatrix(100, 100);
            thirdMatrix = RandomMatrix(1000, 1000);
            fourthMatrix = RandomMatrix(1000, 1000);
        }

        [Test]
        public void IncorrectMatrixSizesTest()
        {
            Assert.Throws<InvalidMatrixSizeException>(() => MatrixManager.MatrixMultiplication(firstMatrix, fourthMatrix));
            
            Assert.Throws<InvalidMatrixSizeException>(() => MatrixManager.MatrixMultiplication(secondMatrix, thirdMatrix));
            
            Assert.DoesNotThrow(() => MatrixManager.MatrixMultiplication(firstMatrix, secondMatrix));
            
            Assert.DoesNotThrow(() => MatrixManager.MatrixMultiplication(thirdMatrix, fourthMatrix));
        }

        [Test]
        public void MatrixMultiplyTest()
        {
            var expectedFirstResult = OrdinaryMatrixMultiplication(firstMatrix, secondMatrix);
            var expectedSecondResult = OrdinaryMatrixMultiplication(thirdMatrix, fourthMatrix);
            
            var wrongFirstResult = new int[100, 100];
            var wrongSecondResult = new int[1000, 1000];
            
            var firstResult = MatrixManager.MatrixMultiplication(firstMatrix, secondMatrix);
            var secondResult = MatrixManager.MatrixMultiplication(thirdMatrix, fourthMatrix);
            
            Assert.IsTrue(FileManagerTest.MatrixAreEqual(firstResult, expectedFirstResult));
            Assert.IsTrue(FileManagerTest.MatrixAreEqual(secondResult, expectedSecondResult));
            
            Assert.IsFalse(FileManagerTest.MatrixAreEqual(firstResult, wrongFirstResult));
            Assert.IsFalse(FileManagerTest.MatrixAreEqual(secondResult, wrongSecondResult));
        }
    }
}
