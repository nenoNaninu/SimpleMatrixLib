namespace MatrixLib
{
    public readonly struct LuDecomposition
    {
        public readonly Matrix L;
        public readonly Matrix U;

        public LuDecomposition(Matrix l, Matrix u)
        {
            L = l;
            U = u;
        }
    }
}