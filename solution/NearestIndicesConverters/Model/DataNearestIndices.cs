﻿namespace solution
{
    interface DataNearestIndices
    {
        ENeighborSide NeighborSide { get; }
        (int r, int c) GetNeighborIndices(int r, int c);
    }
}
