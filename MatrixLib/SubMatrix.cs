using System;

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
    }
}