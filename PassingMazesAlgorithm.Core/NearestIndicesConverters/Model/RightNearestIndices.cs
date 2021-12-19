using PassingMazesAlgorithm.Core.NearestIndicesConverters.Model;

namespace PassingMazesAlgorithm.Core.NearestIndicesConverters.Model
{
    class RightNearestIndices : IDataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Right;
        public (int row, int column) GetNeighborIndices(int row, int column) => (row, column + 1);
    }
}
