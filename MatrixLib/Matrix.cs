using System;
using System.Data;
using System.Text;

namespace MatrixLib
{
    public class Matrix
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
                    builder.Append(this[i, j].ToString());
                    builder.Append(" ");
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

        public LuDecomposition LuSolve()
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

            return new LuDecomposition(lOrigin, uOrigin);
        }
    }
}