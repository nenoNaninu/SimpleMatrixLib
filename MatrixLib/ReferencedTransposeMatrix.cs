using System;
using System.Threading.Tasks;

namespace MatrixLib
{
    public struct ReferencedTransposeMatrix : IMatrix<double>
    {
        private readonly IMatrix<double> _reference;
        public int Row { get; }
        public int Col { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reference">基本的にはMatrixが投げられることを想定.</param>
        public ReferencedTransposeMatrix(IMatrix<double> reference)
        {
            _reference = reference;
            Row = reference.Col;
            Col = reference.Row;
        }

        public double this[int row, int col]
        {
            get
            {
                if (Row <= row || Col <= col)
                {
                    throw new ArgumentException("out of range ReferencedTransposeMatrix [int row, int col]");
                }

                return _reference[col, row];
            }
            set => _reference[col, row] = value;
        }
    }
}