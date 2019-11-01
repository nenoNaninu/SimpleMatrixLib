using System;
using MatrixLib;
using NUnit.Framework;

namespace Matrix.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            var mat = new MatrixLib.Matrix(3, 3);
            mat[0, 0] = 1;
            mat[0, 1] = 2;
            mat[0, 2] = 3;
            
            mat[1, 0] = 4;
            mat[1, 1] = 5;
            mat[1, 2] = 6;
            
            mat[2, 0] = 7;
            mat[2, 1] = 8;
            mat[2, 2] = 9;

            foreach (var item in mat.Array)
            {
                Console.Write(item + " ");
            }

        }
        
        [Test]
        public void SubTest1()
        {
            var mat = new MatrixLib.Matrix(3, 3);
            mat[0, 0] = 1;
            mat[0, 1] = 2;
            mat[0, 2] = 3;
            
            mat[1, 0] = 4;
            mat[1, 1] = 5;
            mat[1, 2] = 6;
            
            mat[2, 0] = 7;
            mat[2, 1] = 8;
            mat[2, 2] = 9;

            var subMat = new SubMatrix(mat, 1, 1, 2, 2);
            subMat[0, 0] = -1;
            subMat[0, 1] = -2;
            subMat[1, 0] = -3;
            subMat[1, 1] = -4;

            Console.WriteLine(mat.ToString());

        }
    }
}