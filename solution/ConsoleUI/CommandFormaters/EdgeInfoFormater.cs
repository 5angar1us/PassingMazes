using solution.Graph.Model;
using System.Text;

namespace solution
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
