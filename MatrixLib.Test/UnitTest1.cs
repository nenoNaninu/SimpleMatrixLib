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
        public void SubMatTest1()
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

        [Test]
        public void SubMatTest2()
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
            Console.WriteLine(mat.Row + " x " + mat.Col);
            Console.WriteLine("===================");
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.Row + " x " + subMat.Col);

            Console.WriteLine("===================");

            subMat = new SubMatrix(subMat, 1, 1, 1, 1);
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.Row + " x " + subMat.Col);
        }

        [Test]
        public void SubMatTest3()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            mat[0, 0] = 1;
            mat[0, 1] = 2;
            mat[0, 2] = 3;
            mat[0, 3] = 4;


            mat[1, 0] = 5;
            mat[1, 1] = 6;
            mat[1, 2] = 7;
            mat[1, 3] = 8;

            mat[2, 0] = 9;
            mat[2, 1] = 10;
            mat[2, 2] = 11;
            mat[2, 3] = 12;

            mat[3, 0] = 13;
            mat[3, 1] = 14;
            mat[3, 2] = 15;
            mat[3, 3] = 16;

            var subMat = new SubMatrix(mat, 1, 1, 3, 3);
            subMat[0, 0] = -1;
            subMat[0, 1] = -2;
            subMat[1, 0] = -3;
            subMat[1, 1] = -4;

            Console.WriteLine(mat.ToString());
            Console.WriteLine(mat.Row + " x " + mat.Col);

            Console.WriteLine("===================");
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.Row + " x " + subMat.Col);

            Console.WriteLine("===================");

            subMat = new SubMatrix(subMat, 1, 1, 2, 2);
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.Row + " x " + subMat.Col);
        }

        [Test]
        public void SubMatTest4()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            mat[0, 0] = 1;
            mat[0, 1] = 2;
            mat[0, 2] = 3;
            mat[0, 3] = 4;


            mat[1, 0] = 5;
            mat[1, 1] = 6;
            mat[1, 2] = 7;
            mat[1, 3] = 8;

            mat[2, 0] = 9;
            mat[2, 1] = 10;
            mat[2, 2] = 11;
            mat[2, 3] = 12;

            mat[3, 0] = 13;
            mat[3, 1] = 14;
            mat[3, 2] = 15;
            mat[3, 3] = 16;

            var subMat = new SubMatrix(mat, 0, 0, 2, 2);
            subMat[0, 0] = -1;
            subMat[0, 1] = -2;
            subMat[1, 0] = -3;
            subMat[1, 1] = -4;

            Console.WriteLine(mat.ToString());
            Console.WriteLine(mat.Row + " x " + mat.Col);

            Console.WriteLine("===================");
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.Row + " x " + subMat.Col);

            Console.WriteLine("===================");

            subMat = new SubMatrix(subMat, 1, 1, 1, 1);
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.Row + " x " + subMat.Col);
        }

        [Test]
        public void LuSolve()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            mat[0, 0] = 8;
            mat[0, 1] = 16;
            mat[0, 2] = 24;
            mat[0, 3] = 32;


            mat[1, 0] = 2;
            mat[1, 1] = 7;
            mat[1, 2] = 12;
            mat[1, 3] = 17;

            mat[2, 0] = 6;
            mat[2, 1] = 17;
            mat[2, 2] = 32;
            mat[2, 3] = 59;

            mat[3, 0] = 7;
            mat[3, 1] = 22;
            mat[3, 2] = 46;
            mat[3, 3] = 105;

            var result = mat.LuSolve();
            Console.WriteLine("L");
            Console.WriteLine(result.L);
            Console.WriteLine("===================");
            Console.WriteLine("U");
            Console.WriteLine(result.U);
        }

        [Test]
        public void 線形Test()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            mat[0, 0] = 8;
            mat[0, 1] = 16;
            mat[0, 2] = 24;
            mat[0, 3] = 32;


            mat[1, 0] = 2;
            mat[1, 1] = 7;
            mat[1, 2] = 12;
            mat[1, 3] = 17;

            mat[2, 0] = 6;
            mat[2, 1] = 17;
            mat[2, 2] = 32;
            mat[2, 3] = 59;

            mat[3, 0] = 7;
            mat[3, 1] = 22;
            mat[3, 2] = 46;
            mat[3, 3] = 105;

            var b = new double[] {160.0, 70, 198, 291};
            var result = mat.SolveSimultaneousEquations(b);

            foreach (var it in result)
            {
                Console.WriteLine(it);
            }

            Console.WriteLine(result);
        }

        [Test]
        public void InverseLowerTriangularMatrixTest()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            mat[0, 0] = 8;
            mat[0, 1] = 16;
            mat[0, 2] = 24;
            mat[0, 3] = 32;


            mat[1, 0] = 2;
            mat[1, 1] = 7;
            mat[1, 2] = 12;
            mat[1, 3] = 17;

            mat[2, 0] = 6;
            mat[2, 1] = 17;
            mat[2, 2] = 32;
            mat[2, 3] = 59;

            mat[3, 0] = 7;
            mat[3, 1] = 22;
            mat[3, 2] = 46;
            mat[3, 3] = 105;

            var lu = mat.LuSolve();
            var l = lu.L;

            var lInv = l.InverseLowerTriangularMatrix();
            Console.WriteLine("l Inv");
            Console.WriteLine(lInv);
            var identity = l * lInv;
            Console.WriteLine(identity);

            identity = lInv * l;
            Console.WriteLine(identity);
        }
        
        [Test]
        public void InverseUpperTriangularMatrixTest()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            mat[0, 0] = 8;
            mat[0, 1] = 16;
            mat[0, 2] = 24;
            mat[0, 3] = 32;


            mat[1, 0] = 2;
            mat[1, 1] = 7;
            mat[1, 2] = 12;
            mat[1, 3] = 17;

            mat[2, 0] = 6;
            mat[2, 1] = 17;
            mat[2, 2] = 32;
            mat[2, 3] = 59;

            mat[3, 0] = 7;
            mat[3, 1] = 22;
            mat[3, 2] = 46;
            mat[3, 3] = 105;

            var lu = mat.LuSolve();
            var u = lu.U;

            var uInv = u.InverseUpperTriangularMatrix();
            Console.WriteLine("u Inv");
            Console.WriteLine(uInv);
            var identity = u * uInv;
            Console.WriteLine(identity);

            identity = uInv * u;
            Console.WriteLine(identity);
        }
    }
}