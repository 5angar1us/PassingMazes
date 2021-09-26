using QuickGraph;
using solution.Graph.Model;
using System.Collections.Generic;

namespace solution
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
