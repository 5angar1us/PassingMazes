using System;
using System.Collections.Generic;
using System.Text;

namespace solution.Converters.NearestIndexes.Model
{
    class TopNearestIndices : IDataNearestIndices
    {
        public ESide NeighborSide { get; } = ESide.Top;
        public (int r, int c) GetNeighborIndices(int r, int c) => (r -1, c);
    }
}
