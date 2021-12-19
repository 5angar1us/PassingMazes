using PassingMazesAlgorithm.Console.UI.ConsoleCommandFormaters;
using PassingMazesAlgorithm.Console.UI.ConsoleCommandFormaters.Abstract;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.Console.UI
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
