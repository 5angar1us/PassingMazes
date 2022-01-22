namespace PassingMazesAlgorithm.Core.NearestIndicesConverters.Model
{
    class BottomNearestIndices : IDataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Bottom;
        public (int row, int column) GetNeighborIndices(int row, int column) => (row + 1, column);
    }
}
