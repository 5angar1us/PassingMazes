using PassingMazesAlgorithm.Core.Graph.Model;
using System.Text;

namespace PassingMazesAlgorithm.Core
{
    public class OptimazedDataCommadFormater : AbstractFormater<OptimazedDataEdge>
    {
        public override void Format(StringBuilder sb, OptimazedDataEdge edge)
        {
            for (int i = 0; i < edge.Count; i++)
            {
                sb.Append(pairs[edge.NeighborSide]);
            }
        }
    }
}
