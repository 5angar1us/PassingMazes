using PassingMazesAlgorithm.Core.Graph.Model;
using System.Collections.Generic;
using System.Text;

namespace PassingMazesAlgorithm.Core
{
    public class ForeachFormater<TEdge> where TEdge : DataEdge
    {
        protected readonly AbstractFormater<TEdge> _commandFormater;

        public ForeachFormater(AbstractFormater<TEdge> commandFormater)
        {
            _commandFormater = commandFormater;
        }

        public string Format(IEnumerable<TEdge> path)
        {
            var sb = new StringBuilder();

            foreach (var edge in path)
                _commandFormater.Format(sb, edge);

            return sb.ToString();
        }
    }
}
