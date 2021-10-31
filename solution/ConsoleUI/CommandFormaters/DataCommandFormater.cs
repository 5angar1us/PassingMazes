using PassingMazesAlgorithm.Core.Graph.Model;
using System.Text;

namespace PassingMazesAlgorithm.Core
{
    public class DataCommandFormater : AbstractFormater<DataEdge>
    {
        public override void Format(StringBuilder sb, DataEdge edge)
        {
            sb.Append(pairs[edge.NeighborSide]);
        }
    }
}

