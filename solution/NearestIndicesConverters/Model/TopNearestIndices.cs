using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    class TopNearestIndices : DataNearestIndices
    {
        public ENeighborSide NeighborSide { get; } = ENeighborSide.Top;
        public (int r, int c) GetNeighborIndices(int r, int c) => (r -1, c);
    }
}
