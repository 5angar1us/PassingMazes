using PassingMazesAlgorithm.Core.Graph.Model;
using System.Text;

namespace PassingMazesAlgorithm.Core
{
    public class EdgeInfoFormater<TEdge> : AbstractFormater<TEdge>
        where TEdge : DataEdge
    {
        public override void Format(StringBuilder sb, TEdge edge)
        {
            sb.Append(edge.Text).Append(' ');
        }
    }
}
