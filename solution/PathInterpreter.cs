using QuickGraph;
using solution.Graph.Model;
using System.Collections.Generic;

namespace solution
{
    class PathInterpreter
    {
        public (string commands, string edgeOrder) Interpriate<TGraph, TEdge>
           (
               CommandFormater<TEdge> commandFormatter,
               CommandFormater<TEdge> edgeInfoFormater,
               PathFinder<TGraph, TEdge> pathFinder
           )
             where TGraph : BidirectionalGraph<DataVertex, TEdge>
             where TEdge : DataEdge
        {
            string commands, edgeOrder;

            if (pathFinder.TryFindPath(out IEnumerable<TEdge> path))
            {
                commands = new Formater<TEdge>(commandFormatter).Format(path);
                edgeOrder = new Formater<TEdge>(edgeInfoFormater).Format(path);
            }
            else
            {
                const string errorText = "Path is not find";
                commands = errorText;
                edgeOrder = errorText;
            }
            return (commands, edgeOrder);
        }
    }
}
