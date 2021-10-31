namespace solution
{
    class LeftNearestIndices : DataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Left;
        public (int r, int c) GetNeighborIndices(int r, int c) => (r, c - 1);
    }
}
