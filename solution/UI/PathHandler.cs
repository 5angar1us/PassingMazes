using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.ConsoleApp.UI
{
    public class PathHandler
    {
        public string Run<TEdge>(AbstractFormater<TEdge> formater, IEnumerable<TEdge> path)

             where TEdge : DataEdge
        {
            return new ForeachFormater<TEdge>(formater).Format(path);
        }
    }
}
