using System.Data.Common;

namespace MatrixLib
{
    public interface IMatrix<T>
    {
        T this[int row, int col] { get; set; }
        int Row { get; }
        int Col { get; }
    }
}