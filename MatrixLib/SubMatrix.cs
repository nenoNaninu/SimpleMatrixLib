using System;
using System.Text;

namespace MatrixLib
{
    public readonly struct SubMatrix : IMatrix<double>
    {
        private readonly Matrix _reference;
        private readonly int _startIndex;

        public int Row { get; }
        public int Col { get; }

        public SubMatrix(Matrix reference, int startSubRow, int startSubCol, int row, int col)
        {
            _startIndex = startSubCol + reference.Col * startSubRow;
            _reference = reference;
            Row = row;
            Col = col;
        }

        public SubMatrix(SubMatrix subMatrix, int startSubRow, int startSubCol, int row, int col)
        {
            _startIndex = subMatrix._startIndex + startSubCol + subMatrix._reference.Col * startSubRow;
            _reference = subMatrix._reference;
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

                return _reference.Array[_startIndex + col + row * _reference.Row];
            }
            set => _reference.Array[_startIndex + col + row * _reference.Row] = value;
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
    }
}