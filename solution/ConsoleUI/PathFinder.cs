using QuickGraph;
using QuickGraph.Algorithms;
using PassingMazesAlgorithm.Core.Graph.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassingMazesAlgorithm.Core
{
    public class PathFinder<TGraph, TEdge>
       where TGraph : BidirectionalGraph<DataVertex, TEdge>
       where TEdge : DataEdge
    {
        private readonly TGraph dataGraph;
        private readonly Func<TEdge, double> edgeCost = e => 1; // constant cost

        public PathFinder(TGraph dataGraph)
        {
            this.dataGraph = dataGraph;
        }

        public IEnumerable<TEdge> Find()

        {
            var vertices = dataGraph.Vertices;

            var root = GetVertexBySymbol(vertices, new Start().Symbol);
            var target = GetVertexBySymbol(vertices, new Quit().Symbol);

            // compute shortest paths
            var tryGetPaths = dataGraph.ShortestPathsDijkstra(edgeCost, root);

            tryGetPaths(target, out IEnumerable<TEdge> path);
            return path;
        }

        private DataVertex GetVertexBySymbol(IEnumerable<DataVertex> vertices, char symbol)
        {
            return vertices.First(x => x.Symbol == symbol);
        }
    }
}
