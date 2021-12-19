using PassingMazesAlgorithm.Console.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Text;

namespace PassingMazesAlgorithm.Console.UI.ConsoleCommandFormaters
{
    public class EdgeInfoFormater<TEdge> : AbstractFormater<TEdge>
        where TEdge : DataEdge
    {
        public override void Format(StringBuilder sb, TEdge edge)
        {
            sb.Append(edge).Append(' ');
        }
    }
}
