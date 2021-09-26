using solution.Graph.Model;
using System.Text;

namespace solution
{
    public class DataCommandFormater : AbstractFormater<DataEdge>
    {
        public override void Format(StringBuilder sb, DataEdge edge)
        {
            sb.Append(pairs[edge.NeighborSide]);
        }
    }
}

