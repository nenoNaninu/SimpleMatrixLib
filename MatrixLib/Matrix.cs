using System;
using System.Data;
using System.Text;

namespace MatrixLib
{
    public class Matrix : IMatrix<double>
    {
        public double[] Array { get; }

        /// <summary>
        /// 行数
        /// </summary>
        public int Row { get; }

        /// <summary>
        /// 列数
        /// </summary>
        public int Col { get; }

        public Matrix(double[] array, int row, int col)
        {
            Array = array;
            Row = row;
            Col = col;
        }

        public Matrix(int row, int col)
        {
            Array = new double[row * col];
            Row = row;
            Col = col;
        }


        public double this[int row, int col]
        {
            get
            {
                if (row >= Row || col >= Col)
                {
                    throw new ArgumentException("this[int row, int col] out of range");
                }

                return Array[col + row * Col];
            }
            set
            {
                if (row >= Row || col >= Col)
                {
                    throw new ArgumentException("this[int row, int col] out of range");
                }

                Array[col + row * Col] = value;
            }
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < Row; i++)
            {
                for (int j = 0; j < Col; j++)
                {
                    builder.Append($"{this[i, j]:N3} ");
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }

        public static Matrix Identity(int row)
        {
            var mat = new Matrix(row, row);
            for (int i = 0; i < row; i++)
            {
                mat[i, i] = 1;
            }

            return mat;
        }

        public Matrix DeepCopy()
        {
            var newArray = new double[this.Array.Length];
            System.Array.Copy(this.Array, newArray, newArray.Length);
            return new Matrix(newArray, this.Row, this.Col);
        }

        public LuDecompositionResult LuSolve()
        {
            if (Row != Col)
            {
                throw new DataException("row and col must be same");
            }

            var lOrigin = new Matrix(Row, Col);
            var uOrigin = Matrix.Identity(Row);

            var a = new SubMatrix(this.DeepCopy(), 0, 0, Row, Col);
            var l = new SubMatrix(lOrigin, 0, 0, Row, Col);
            var u = new SubMatrix(uOrigin, 0, 0, Row, Col);

            for (int i = 0; i < this.Row; i++)
            {
                //l00
                l[0, 0] = a[0, 0];

                //copy l1
                for (int j = 1; j < a.Row; j++)
                {
                    l[j, 0] = a[j, 0];
                }

                //copy u1
                for (int j = 1; j < a.Row; j++)
                {
                    u[0, j] = a[0, j] / l[0, 0];
                }

                for (int j = 1; j < a.Col; j++)
                {
                    for (int k = 1; k < a.Col; k++)
                    {
                        a[j, k] -= l[j, 0] * u[0, k];
                    }
                }

                a = new SubMatrix(a, 1, 1, a.Row - 1, a.Col - 1);
                l = new SubMatrix(l, 1, 1, l.Row - 1, l.Col - 1);
                u = new SubMatrix(u, 1, 1, u.Row - 1, u.Col - 1);
            }

            return new LuDecompositionResult(lOrigin, uOrigin);
        }

        /// <summary>
        /// このMatrix(this.)がAだとしたとき、
        /// b = Axのxを求める。
        /// </summary>
        /// <param name="b"></param>
        /// <returns>x</returns>
        public double[] SolveSimultaneousEquations(double[] b)
        {
            var luResult = this.LuSolve();
            var l = luResult.L;
            var u = luResult.U;

            //Ly = bのyを求める
            Span<double> y = stackalloc double[b.Length];

            y[0] = b[0] / l[0, 0];

            for (int i = 1; i < y.Length; i++)
            {
                var sum = 0.0;

                for (int j = 0; j < i; j++)
                {
                    sum += y[j] * l[i, j];
                }

                y[i] = (b[i] - sum) / l[i, i];
            }

            var x = new double[b.Length];

            x[^1] = y[^1];

            //Ux = yのxを求める
            for (int i = y.Length - 1; 0 <= i; i--)
            {
                var sum = 0.0;
                for (int j = i + 1; j < y.Length; j++)
                {
                    sum += u[i, j] * x[j];
                }

                x[i] = y[i] - sum;
            }

            return x;
        }

        public Matrix Inverse()
        {
            var luResult = this.LuSolve();
            var l = luResult.L;
            var u = luResult.U;
            return u.InverseUpperTriangularMatrix() * l.InverseLowerTriangularMatrix();
        }

        /// <summary>
        /// 上三角行列かの確認はしないので自己責任。
        /// </summary>
        /// <returns></returns>
        public Matrix InverseUpperTriangularMatrix()
        {
            //上三角行列の逆行列は上三角行列
            if (this.Col != this.Row)
            {
                throw new Exception("Col and Row must be same");
            }

            var answer = new Matrix(this.Row, this.Col);

            for (int i = 0; i < answer.Col; i++)
            {
                //answer[~,i]が見ている列のベクトル
                answer[i, i] = 1 / this[i, i];

                for (int j = i - 1; 0 <= j; j--)
                {
                    double sum = 0.0;

                    for (int k = j + 1; k < answer.Row; k++)
                    {
                        sum += answer[k, i] * this[j, k];
                    }
                    
                    answer[j, i] = -sum / this[i, i];
                }
            }
            
            return answer;
        }

        /// <summary>
        /// 下三角行列かの確認はしないので自己責任。
        /// </summary>
        /// <returns></returns>
        public Matrix InverseLowerTriangularMatrix()
        {
            //上三角行列の逆行列は上三角行列
            if (this.Col != this.Row)
            {
                throw new Exception("Col and Row must be same");
            }

            var answer = new Matrix(this.Row, this.Col);

            for (int i = 0; i < answer.Col; i++)
            {
                //逆行列の各列ごとに求めて行く。
                //answer[~,i]が見ている列のベクトル
                answer[i, i] = 1 / this[i, i];

                for (int j = i + 1; j < this.Row; j++)
                {
                    double sum = 0.0;

                    for (int k = i; k <= j; k++)
                    {
                        sum += this[j, k] * answer[k, i];
                    }

                    answer[j, i] = -sum / this[j, j];
                }
            }
            return answer;
        }

        public Matrix PseudoInverse()
        {
            return null;
        }

        public static Matrix operator *(Matrix l, Matrix r)
        {
            if (l.Col != r.Row)
            {
                throw new ArgumentException("l.Col and r.Row must be same.");
            }

            var answer = new Matrix(l.Row, r.Col);

            for (int i = 0; i < answer.Row; i++)
            {
                for (int j = 0; j < answer.Col; j++)
                {
                    for (int k = 0; k < l.Col; k++)
                    {
                        answer[i, j] += l[i, k] * r[k, j];
                    }
                }
            }

            return answer;
        }

        public static Matrix operator *(Matrix l, ReferencedTransposeMatrix r)
        {
            if (l.Col != r.Row)
            {
                throw new ArgumentException("l.Col and r.Row must be same.");
            }

            var answer = new Matrix(l.Row, r.Col);

            for (int i = 0; i < answer.Row; i++)
            {
                for (int j = 0; j < answer.Col; j++)
                {
                    for (int k = 0; k < l.Col; k++)
                    {
                        answer[i, j] += l[i, k] * r[k, j];
                    }
                }
            }

            return answer;
        }

        public static Matrix operator *(ReferencedTransposeMatrix l, Matrix r)
        {
            if (l.Col != r.Row)
            {
                throw new ArgumentException("l.Col and r.Row must be same.");
            }

            var answer = new Matrix(l.Row, r.Col);

            for (int i = 0; i < answer.Row; i++)
            {
                for (int j = 0; j < answer.Col; j++)
                {
                    for (int k = 0; k < l.Col; k++)
                    {
                        answer[i, j] += l[i, k] * r[k, j];
                    }
                }
            }

            return answer;
        }
    }
}