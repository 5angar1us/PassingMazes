using PassingMazesAlgorithm.Console.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Text;

namespace PassingMazesAlgorithm.Console.UI.ConsoleCommandFormaters
{
    public class DataCommandFormater : AbstractFormater<DataEdge>
    {
        public override void Format(StringBuilder sb, DataEdge edge)
        {
            sb.Append(_pairs[edge.NeighborSide]);
        }
    }
}

