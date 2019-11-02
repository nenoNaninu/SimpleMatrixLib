using System;
using MatrixLib;
using NUnit.Framework;
using MathNet.Numerics.LinearAlgebra.Double;

namespace Matrix.Test
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void 部分行列の確認()
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
        public void 部分行列確認その2()
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
            Console.WriteLine(mat.RowCount + " x " + mat.ColCount);
            Console.WriteLine("===================");
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.RowCount + " x " + subMat.ColCount);

            Console.WriteLine("===================");

            subMat = new SubMatrix(subMat, 1, 1, 1, 1);
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.RowCount + " x " + subMat.ColCount);
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
            Console.WriteLine(mat.RowCount + " x " + mat.ColCount);

            Console.WriteLine("===================");
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.RowCount + " x " + subMat.ColCount);

            Console.WriteLine("===================");

            subMat = new SubMatrix(subMat, 1, 1, 2, 2);
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.RowCount + " x " + subMat.ColCount);
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
            Console.WriteLine(mat.RowCount + " x " + mat.ColCount);

            Console.WriteLine("===================");
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.RowCount + " x " + subMat.ColCount);

            Console.WriteLine("===================");

            subMat = new SubMatrix(subMat, 1, 1, 1, 1);
            Console.WriteLine(subMat.ToString());
            Console.WriteLine(subMat.RowCount + " x " + subMat.ColCount);
        }

        [Test]
        public void LU分解コンソール確認用()
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
        public void 下三角行列の逆行列が計算できているか確認()
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
        public void u分解テスト()
        {
            var denseMat = DenseMatrix.OfArray(new double[,]
            {
                {8, 16, 24, 32},
                {2, 7, 12, 17},
                {6, 17, 32, 59},
                {7, 22, 46, 105}
            });

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

            var uCorrect = denseMat.LU().U;

            Console.WriteLine(u);
            Console.WriteLine(uCorrect);
//            
//            for (int i = 0; i < 4; i++)
//            {
//                for (int j = 0; j < 4; j++)
//                {
//                    Assert.IsTrue(Math.Abs(u[i,j] - uCorrect[i,j]) < 0.001);
//                }
//            }
        }

        [Test]
        public void 逆行列テスト()
        {
            var denseMat = DenseMatrix.OfArray(new double[,]
            {
                {8, 16, 24, 32},
                {2, 7, 12, 17},
                {6, 17, 32, 59},
                {7, 22, 46, 105}
            });
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

            var inv = mat.Inverse();
            var invCorrect = denseMat.Inverse();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.IsTrue(Math.Abs(invCorrect[i, j] - inv[i, j]) < 0.001);
                }
            }
        }

        [Test]
        public void 逆行列テストランダム版()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            var rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mat[i, j] = rand.Next(0, 20);
                }
            }

            var denseMat = new DenseMatrix(4, 4);
            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    denseMat[i, j] = mat[i, j];
                }
            }

            var inv = mat.Inverse();
            var invCorrect = denseMat.Inverse();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.IsTrue(Math.Abs(invCorrect[i, j] - inv[i, j]) < 0.001);
                }
            }
        }

        [Test]
        public void LU分解テスト()
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
            var restore = lu.L * lu.U;

            Console.WriteLine(mat);
            Console.WriteLine(restore);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                }
            }
        }

        [Test]
        public void LU分解テストランダム版()
        {
            var mat = new MatrixLib.Matrix(4, 4);
            var rand = new Random();

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    mat[i, j] = rand.Next(0, 20);
                }
            }

            var lu = mat.LuSolve();
            var restore = lu.L * lu.U;

            Console.WriteLine(mat);
            Console.WriteLine(restore);

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    Assert.IsTrue(Math.Abs(mat[i, j] - restore[i, j]) < 0.001);
                }
            }
        }

        [Test]
        public void 転置チェックランダム版()
        {
            int row = 4;
            int col = 8;
            var mat = new MatrixLib.Matrix(row, col);
            var rand = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mat[i, j] = rand.Next(0, 20);
                }
            }

            var denseMat = new DenseMatrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    denseMat[i, j] = mat[i, j];
                }
            }
            
            Console.WriteLine(mat * mat.Transpose());
            Console.WriteLine(denseMat * denseMat.Transpose());
        }

        [Test]
        public void 擬似逆行列のランダムテスト()
        {
            int row = 8;
            int col = 4;
            var mat = new MatrixLib.Matrix(row, col);
            var rand = new Random();

            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    mat[i, j] = rand.Next(0, 20);
                }
            }

            var denseMat = new DenseMatrix(row, col);
            for (int i = 0; i < row; i++)
            {
                for (int j = 0; j < col; j++)
                {
                    denseMat[i, j] = mat[i, j];
                }
            }
            
            Console.WriteLine(denseMat.PseudoInverse());
            Console.WriteLine(mat.PseudoInverse());
            var pseInv = mat.PseudoInverse();
            var densePseInv = denseMat.PseudoInverse();

            for (int i = 0; i < pseInv.RowCount; i++)
            {
                for (int j = 0; j < pseInv.ColCount; j++)
                {
                    Assert.IsTrue(Math.Abs(pseInv[i, j] - densePseInv[i, j]) < 0.001);
                }
            }
        }
    }
}