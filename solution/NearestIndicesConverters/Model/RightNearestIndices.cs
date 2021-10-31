namespace solution
{
    class RightNearestIndices : DataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Right;
        public (int r, int c) GetNeighborIndices(int r, int c) => (r, c + 1);
    }
}
