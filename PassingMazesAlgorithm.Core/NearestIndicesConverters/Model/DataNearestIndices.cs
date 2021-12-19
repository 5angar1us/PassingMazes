namespace PassingMazesAlgorithm.Core
{
    interface DataNearestIndices
    {
        ENeighborSide NeighborSide { get; }
        (int row, int column) GetNeighborIndices(int row, int column);
    }
}
