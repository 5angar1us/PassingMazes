using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.Parsers;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.Core
{
    public class Maze
    {
        private MapParser parser = new MapParser(new MapFormatChecker());
        private MapConverter mapConverter = new MapConverter();

        public IEnumerable<DataEdge> FindWay(string textMap)
        {
            Map map = parser.Parse(textMap);

            DataGraph graph = mapConverter.ToGraph(map);

            var pathfindingAlgorithm = new ShortestPathsDijkstra<DataGraph, DataEdge>();
            return pathfindingAlgorithm.Find(graph);
        }
    }
}
