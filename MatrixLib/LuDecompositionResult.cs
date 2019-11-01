namespace MatrixLib
{
    public readonly struct LuDecompositionResult
    {
        public readonly Matrix L;
        public readonly Matrix U;

        public LuDecompositionResult(Matrix l, Matrix u)
        {
            L = l;
            U = u;
        }
    }
}