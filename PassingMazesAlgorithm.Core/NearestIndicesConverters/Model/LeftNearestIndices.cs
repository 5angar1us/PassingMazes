using PassingMazesAlgorithm.Core.NearestIndicesConverters.Model;

namespace PassingMazesAlgorithm.Core.NearestIndicesConverters.Model
{
    class LeftNearestIndices : IDataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Left;
        public (int row, int column) GetNeighborIndices(int row, int column) => (row, column - 1);
    }
}
