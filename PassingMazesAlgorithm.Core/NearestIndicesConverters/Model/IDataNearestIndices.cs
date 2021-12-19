namespace PassingMazesAlgorithm.Core.NearestIndicesConverters.Model
{
    interface IDataNearestIndices
    {
        ENeighborSide NeighborSide { get; }
        (int row, int column) GetNeighborIndices(int row, int column);
    }
}
