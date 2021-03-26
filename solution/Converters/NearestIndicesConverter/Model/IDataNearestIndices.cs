namespace solution.Converters.NearestIndexes.Model
{
    interface IDataNearestIndices 
    {
        ESide NeighborSide { get; }
        (int r, int c) GetNeighborIndices(int r, int c);

    }
}
