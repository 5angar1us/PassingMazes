using PassingMazesAlgorithm.Core.NearestIndicesConverters.Model;

namespace PassingMazesAlgorithm.Core.NearestIndicesConverters.Model
{
    class TopNearestIndices : IDataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Top;
        public (int row, int column) GetNeighborIndices(int row, int column) => (row - 1, column);
    }
}
