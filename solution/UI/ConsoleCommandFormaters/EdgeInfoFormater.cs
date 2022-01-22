using System.Text;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;

namespace PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters
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
