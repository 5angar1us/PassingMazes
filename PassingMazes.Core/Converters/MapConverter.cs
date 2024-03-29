﻿using System.Collections.Generic;
using System.Linq;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;
using PassingMazesAlgorithm.Core.NearestIndicesConverters;

namespace PassingMazesAlgorithm.Core.Converters
{
    public class MapConverter
    {
        private readonly NearestIndexConvertersFactory _nearestIndexConvertersFactory = new NearestIndexConvertersFactory();

        public MapConverter()
        {

        }

        public DataGraph ToGraph(Maze map)
        {
            var dataGraph = new DataGraph();

            IEnumerable<DataVertex> vertices = CreateVertices(map);
            dataGraph.AddVertexRange(vertices);

            IEnumerable<DataEdge> dataEdges = CreateEdges(map, vertices);
            dataGraph.AddEdgeRange(dataEdges);

            return dataGraph;
        }

        private IEnumerable<DataVertex> CreateVertices(Maze map)
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

        private IEnumerable<DataEdge> CreateEdges(Maze map, IEnumerable<DataVertex> vertices)
        {
            return vertices
                .Select(vertex => CreateEdge(map, vertex, vertices))
                .SelectMany(x => x);
        }

        private IEnumerable<DataEdge> CreateEdge(Maze map, DataVertex sourceVertex, IEnumerable<DataVertex> vertices)
        {
            (int row, int column) = map.IndexOf(sourceVertex.Name);

            IEnumerable<((int row, int column) indices, ENeighborSide neighborSide)> indicesNeighborVertexces = _nearestIndexConvertersFactory.NearestIndiceConvertors
                .Select(nearestIndice =>
                {
                    return (indices: nearestIndice.GetNeighborIndices(row, column), neighborSide: nearestIndice.NeighborSide);
                });

            IEnumerable<(DataVertex vertex, ENeighborSide neighborSide)> neighborVertexces = indicesNeighborVertexces
               .Select(neighbor =>
               {
                   return (map[neighbor.indices].Name, neighbor.neighborSide);
               })
               .Join(
                    vertices,
                    neighbornData => neighbornData.Name,
                    vertex => vertex.Name,
                    (neighbornData, vertex) => (vertex, neighbornData.neighborSide));

            IEnumerable<DataEdge> edges = neighborVertexces.Select(neighborVertex =>
            {
                (DataVertex targetVertex, ENeighborSide neighborSide) = neighborVertex;
                return new DataEdge(sourceVertex, targetVertex, neighborSide);
            });

            return edges;
        }


    }
}
