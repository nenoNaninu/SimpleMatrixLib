using System;
using System.Text;

namespace MatrixLib
{
    public readonly struct SubMatrix : IMatrix<double>
    {
        private readonly Matrix _reference;
        private readonly int _startIndex;

        public int RowCount { get; }
        public int ColCount { get; }

        public SubMatrix(Matrix reference, int startSubRow, int startSubCol, int row, int col)
        {
            _startIndex = startSubCol + reference.ColCount * startSubRow;
            _reference = reference;
            RowCount = row;
            ColCount = col;
        }

        public SubMatrix(SubMatrix subMatrix, int startSubRow, int startSubCol, int row, int col)
        {
            _startIndex = subMatrix._startIndex + startSubCol + subMatrix._reference.ColCount * startSubRow;
            _reference = subMatrix._reference;
            RowCount = row;
            ColCount = col;
        }

        public double this[int row, int col]
        {
            get
            {
                if (row >= RowCount || col >= ColCount)
                {
                    throw new ArgumentException("this[int row, int col] out of range");
                }

                return _reference.Array[_startIndex + col + row * _reference.RowCount];
            }
            set => _reference.Array[_startIndex + col + row * _reference.RowCount] = value;
        }

        public override string ToString()
        {
            var builder = new StringBuilder();
            for (int i = 0; i < RowCount; i++)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    builder.Append($"{this[i, j]:N3} ");
                }

                builder.Append(Environment.NewLine);
            }

            return builder.ToString();
        }
    }
}