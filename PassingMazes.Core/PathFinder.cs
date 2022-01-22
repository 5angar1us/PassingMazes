using System.Collections.Generic;
using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model;

namespace PassingMazesAlgorithm.Core
{
    public class PathFinder
    {
        private readonly MapConverter _mapConverter;

        public PathFinder(MapConverter mapConverter)
        {
            this._mapConverter = mapConverter;
        }

        public IEnumerable<DataEdge> Find(Maze map)
        {
            DataGraph graph = _mapConverter.ToGraph(map);

            var pathfindingAlgorithm = new ShortestPathsDijkstra<DataGraph, DataEdge>();
            return pathfindingAlgorithm.Find(graph);
        }
    }
}
