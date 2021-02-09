using QuickGraph;
using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace solution
{
    class MapConverter
    {
        public DataGraph ToGraph(MyMap map)
        {
            var vertices = CreateVertices(map);

            var dataGraph = new DataGraph();
            dataGraph.AddVertexRange(vertices);

            var dataEdges = CreateEdges(map, vertices);
            dataGraph.AddEdgeRange(dataEdges);

            return dataGraph;
        }

       

        private IEnumerable<DataEdge> CreateEdges(MyMap map, IEnumerable<DataVertex> vertices)
        {
            return vertices
                .Select(vertex =>
                {
                    (int r, int c) = map.IndexOfCellByName(vertex.Name);
                    var neighbors = GetNeihbors(map, r, c);
                    var neighborVertexces = GetVertexcesByNameWithNeighborSide(vertices, neighbors);
                    var edges = GetEdges(vertex, neighborVertexces);
                    return edges;
                })
                .SelectMany(x => x);

        }

        private IEnumerable<(DataVertex, ENeighborSide neighborSide)> GetVertexcesByNameWithNeighborSide
            (
                IEnumerable<DataVertex> vertices,
                IEnumerable<(MapObject mapObject, ENeighborSide neighborSide)> neighbors
            )
        {
            return vertices.Join(
                 neighbors,
                 v => v.Name,
                 n => n.mapObject.Name,
                 (v, n) => (vertex: v, neighborVertex: n.neighborSide));
        }


        private IEnumerable<DataEdge> GetEdges(DataVertex source, IEnumerable<(DataVertex neighborVertex, ENeighborSide neighborSide)> neighborVertexces)
        {
            var edges = new List<DataEdge>();
            return neighborVertexces.Select(x =>
            {
                var target = x.neighborVertex;

                string textFormat  = $"{source.Name}->{target.Name}";
                var edge = new DataEdge(source, target) { Text = textFormat, NeighborSide = x.neighborSide };

                return edge;
            });
        }

        private IEnumerable<(MapObject mapObject, ENeighborSide neighborSide)> GetNeihbors(MyMap map, int r, int c)
        {
            var nearestIndiceConvertors = NearestIndexConvertersFactory.NearestIndiceConvertors;
            return nearestIndiceConvertors.Select(x =>
            {
                (int i, int j) = x.GetNeighborIndices(r, c);
                return (map[i, j], x.NeighborSide);
            }).ToList();
        }

        private IEnumerable<DataVertex> CreateVertices(MyMap map)
        {
            var vertices = new List<DataVertex>();
            var wall = new Wall();
            for (int r = 1; r < map.Height - 1; r++)
            {
                for (int c = 1; c < map.Width - 1; c++)
                {
                    var elem = map[r, c];
                    if (!elem.EqualsBySybmol(wall))

                        vertices.Add(new DataVertex(elem.Symbol, elem.Name));
                }
            }

            return vertices;
        }
    }
}
