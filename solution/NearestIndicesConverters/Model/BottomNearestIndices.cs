namespace solution
{
    class BottomNearestIndices : DataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Bottom;
        public (int r, int c) GetNeighborIndices(int r, int c) => (r + 1, c);
    }
}
