using System;
using System.Text;
using System.Threading.Tasks;

namespace MatrixLib
{
    public struct ReferencedTransposeMatrix : IMatrix<double>
    {
        private readonly IMatrix<double> _reference;
        public int RowCount { get; }
        public int ColCount { get; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="reference">基本的にはMatrixが投げられることを想定.</param>
        public ReferencedTransposeMatrix(IMatrix<double> reference)
        {
            _reference = reference;
            RowCount = reference.ColCount;
            ColCount = reference.RowCount;
        }

        public double this[int row, int col]
        {
            get
            {
                if (RowCount <= row || ColCount <= col)
                {
                    throw new ArgumentException("out of range ReferencedTransposeMatrix [int row, int col]");
                }

                return _reference[col, row];
            }
            set => _reference[col, row] = value;
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