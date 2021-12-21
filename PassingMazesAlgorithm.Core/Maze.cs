using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.Parsers;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.Core
{
    public class Maze
    {
        private MapParser _parser ;
        private MapConverter _mapConverter;

        public Maze(MapParser parser, MapConverter mapConverter)
        {
            this._parser = parser;
            this._mapConverter = mapConverter;
        }

        public IEnumerable<DataEdge> FindWay(string textMap)
        {
            Map map = _parser.Parse(textMap);

            DataGraph graph = _mapConverter.ToGraph(map);

            var pathfindingAlgorithm = new ShortestPathsDijkstra<DataGraph, DataEdge>();
            return pathfindingAlgorithm.Find(graph);
        }
    }
}
