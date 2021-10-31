using QuickGraph;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.Core
{
    public class PathInterpreter
    {
        public string Interpriate<TEdge>(AbstractFormater<TEdge> formater, IEnumerable<TEdge> path)

             where TEdge : DataEdge
        {
            return new ForeachFormater<TEdge>(formater).Format(path);
        }
    }
}
