using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;
using System.Collections.Generic;
using System.Linq;
using PassingMazesAlgorithm.Core.NearestIndicesConverters.Model;
using PassingMazesAlgorithm.Core.NearestIndicesConverters;

namespace PassingMazesAlgorithm.Core.Converters
{
    internal class MapConverter
    {
        private List<DataNearestIndices> _nearestIndiceConvertors = NearestIndexConvertersFactory.NearestIndiceConvertors.ToList();

        public DataGraph ToGraph(Map map)
        {
            var dataGraph = new DataGraph();

            IEnumerable<DataVertex> vertices = CreateVertices(map);
            dataGraph.AddVertexRange(vertices);

            IEnumerable<DataEdge> dataEdges = CreateEdges(map, vertices);
            dataGraph.AddEdgeRange(dataEdges);

            return dataGraph;
        }

        private IEnumerable<DataVertex> CreateVertices(Map map)
        {
            var vertices = new List<DataVertex>();
            var wall = new Wall();

            map.ProcessFunctionOverNotWallData((row, column) =>
            {
                MapObject elem = map[row, column];

                if (elem.Symbol.Equals(wall.Symbol) == false)
                    vertices.Add(new DataVertex(elem.Symbol, elem.Name));
            });

            return vertices;
        }

        private IEnumerable<DataEdge> CreateEdges(Map map, IEnumerable<DataVertex> vertices)
        {
            return vertices
                .Select(vertex => CreateEdge(map, vertex, vertices))
                .SelectMany(x => x);
        }

        private IEnumerable<DataEdge> CreateEdge(Map map, DataVertex sourceVertex, IEnumerable<DataVertex> vertices)
        {
            (int row, int column) = map.IndexOf(sourceVertex.Name);

            IEnumerable<(DataVertex, ENeighborSide neighborSide)> neighborVertexcesData = _nearestIndiceConvertors
                .Select(nearestIndice => (indices: nearestIndice.GetNeighborIndices(row, column), neighborSide: nearestIndice.NeighborSide))
                .Select(neighbor => (map[neighbor.indices].Name, neighbor.neighborSide))
                .Join(
                    vertices,
                    neighbornData => neighbornData.Name,
                    vertex => vertex.Name,
                    (neighbornData,  vertex) => (vertex, neighbornData.neighborSide));

            IEnumerable<DataEdge> edges = neighborVertexcesData.Select(neighborVertexcData =>
            {
                (DataVertex targetVertex, ENeighborSide neighborSide) = neighborVertexcData;
                return new DataEdge(sourceVertex, targetVertex, neighborSide);
            });
            return edges;
        }


    }
}
