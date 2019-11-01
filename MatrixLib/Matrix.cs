using System;
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
    }
}