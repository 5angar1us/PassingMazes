using System;
using System.Collections.Generic;
using System.Text;

namespace solution.Converters.NearestIndexes.Model
{
    class LeftNearestIndices : IDataNearestIndices
    {
        public ESide NeighborSide { get; } = ESide.Left;
        public (int r, int c) GetNeighborIndices(int r, int c) => (r, c - 1);

    }
}
