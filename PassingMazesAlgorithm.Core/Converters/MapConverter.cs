using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.GameMap.Model;
using PassingMazesAlgorithm.Core.GameMap.Model.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassingMazesAlgorithm.Core.Converters
{
    internal class MapConverter
    {
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

            for (int row = 1; row < map.Height - 1; row++)
            {
                for (int column = 1; column < map.Width - 1; column++)
                {
                    MapObject elem = map[row, column];
                    if (elem.Symbol.Equals(wall.Symbol) == false)
                        vertices.Add(new DataVertex(elem.Symbol, elem.Name));
                }
            }

            return vertices;
        }

        private IEnumerable<DataEdge> CreateEdges(Map map, IEnumerable<DataVertex> vertices)
        {
            return vertices
                .Select(vertex =>
                {
                    (int row, int column) = map.IndexOfCellByName(vertex.Name);
                    IEnumerable<(MapObject mapObject, ENeighborSide neighborSide)> neighborsData = GetNeihborsObjectData(map, row, column);
                    IEnumerable<(DataVertex, ENeighborSide neighborSide)> neighborVertexcesData = GetNeighborVertexcesData(vertices, neighborsData);
                    return CreateVertexEdges(vertex, neighborVertexcesData);
                })
                .SelectMany(x => x);
        }

        private IEnumerable<(MapObject mapObject, ENeighborSide neighborSide)> GetNeihborsObjectData(Map map, int row, int column)
        {
            var nearestIndiceConvertors = NearestIndexConvertersFactory.NearestIndiceConvertors.ToList();
            return nearestIndiceConvertors.ConvertAll(x =>
            {
                (int newRow, int newColumn) = x.GetNeighborIndices(row, column);
                return (map[newRow, newColumn], x.NeighborSide);
            });
        }

        private IEnumerable<(DataVertex, ENeighborSide neighborSide)> GetNeighborVertexcesData
            (
                IEnumerable<DataVertex> vertices,
                IEnumerable<(MapObject mapObject, ENeighborSide neighborSide)> neighborsData
            )
        {
            return vertices.Join(
                 neighborsData,
                 vertice => vertice.Name,
                 neighbornData => neighbornData.mapObject.Name,
                 (vertice, neighbornData) => (vertex: vertice, neighborVertex: neighbornData.neighborSide));
        }

        private IEnumerable<DataEdge> CreateVertexEdges(DataVertex source, IEnumerable<(DataVertex neighborVertex, ENeighborSide neighborSide)> neighborVertexces)
        {
            return neighborVertexces.Select(x =>
            {
                DataVertex target = x.neighborVertex;

                string textFormat = $"{source.Name}->{target.Name}";
                return new DataEdge(source, target) { Text = textFormat, NeighborSide = x.neighborSide };
            });
        }


    }
}
