using solution.Graph.Model;
using solution.Map.Model;
using solution.Map.Model.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace solution.Converters
{
    class MapConverter
    {
        public DataGraph ToGraph(GameMap map)
        {
            var dataGraph = new DataGraph();
            
            var vertices = CreateVertices(map);
            dataGraph.AddVertexRange(vertices);

            var dataEdges = CreateEdges(map, vertices);
            dataGraph.AddEdgeRange(dataEdges);

            return dataGraph;
        }

        private IEnumerable<DataVertex> CreateVertices(GameMap map)
        {
            var vertices = new List<DataVertex>();
            var wall = new Wall();

            for (int row = 1; row < map.Height - 1; row++)
            {
                for (int column = 1; column < map.Width - 1; column++)
                {
                    var elem = map[row, column];
                    if (!elem.Symbol.Equals(wall.Symbol))
                        vertices.Add(new DataVertex(elem.Symbol, elem.Name));
                }
            }

            return vertices;
        }

        private IEnumerable<DataEdge> CreateEdges(GameMap map, IEnumerable<DataVertex> vertices)
        {
            return vertices
                .Select(vertex =>
                {
                    (int row, int column) = map.IndexOfCellByName(vertex.Name);
                    var neihborsData = GetNeihborsObjectData(map, row, column);
                    var neighborVertexcesData = GetNeighborVertexcesData(vertices, neihborsData);
                    return CreateVertexEdges(vertex, neighborVertexcesData);
                })
                .SelectMany(x => x);

        }


        private IEnumerable<(MapObject mapObject, ENeighborSide neighborSide)> GetNeihborsObjectData(GameMap map, int row, int column)
        {
            var nearestIndiceConvertors = NearestIndexConvertersFactory.NearestIndiceConvertors;
            return nearestIndiceConvertors.ConvertAll(x =>
            {
                (int i, int j) = x.GetNeighborIndices(row, column);
                return (map[i, j], x.NeighborSide);
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
            var edges = new List<DataEdge>();
            return neighborVertexces.Select(x =>
            {
                var target = x.neighborVertex;

                string textFormat  = $"{source.Name}->{target.Name}";
                return new DataEdge(source, target) { Text = textFormat, NeighborSide = x.neighborSide };
            });
        }

        

        
    }
}
