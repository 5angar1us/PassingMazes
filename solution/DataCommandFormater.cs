using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    class DataCommandFormater : CommandFormater<DataEdge>
    {
        public DataCommandFormater() : base(
            (sb, edge) =>
            {
                sb.Append($"{pairs[edge.NeighborSide]}");
            })
        { }
    }
}

