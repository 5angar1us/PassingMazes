using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Text;

namespace PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters
{
    public class DataCommandFormater : AbstractFormater<DataEdge>
    {
        public override void Format(StringBuilder sb, DataEdge edge)
        {
            sb.Append(_pairs[edge.NeighborSide]);
        }
    }
}

