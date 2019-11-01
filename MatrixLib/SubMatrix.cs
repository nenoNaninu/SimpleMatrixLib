using System;
using System.Text;

namespace MatrixLib
{
    public readonly struct SubMatrix
    {
        public readonly Matrix Original;
        public readonly int Row;
        public readonly int Col;
        private readonly int _startIndex;

        public SubMatrix(Matrix original, int startSubRow, int startSubCol, int row, int col)
        {
            _startIndex = startSubCol + original.Col * startSubRow;
            Original = original;
            Row = row;
            Col = col;
        }

        public SubMatrix(SubMatrix subMatrix, int startSubRow, int startSubCol, int row, int col)
        {
            _startIndex = subMatrix._startIndex + startSubCol + subMatrix.Original.Col * startSubRow;
            Original = subMatrix.Original;
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

                return Original.Array[_startIndex + col + row * Original.Row];
            }
            set => Original.Array[_startIndex + col + row * Original.Row] = value;
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