using System;
using System.Collections.Generic;
using System.Linq;
using PassingMazesAlgorithm.Core.Graph.Model;
using QuickGraph;
using QuickGraph.Algorithms;

namespace PassingMazesAlgorithm.Core
{
    public class ShortestPathsDijkstra<TGraph, TEdge>
       where TGraph : BidirectionalGraph<DataVertex, TEdge>
       where TEdge : DataEdge
    {
        private readonly Func<TEdge, double> _edgeCost = e => 1; // constant cost

        public IEnumerable<TEdge> Find(TGraph dataGraph)

        {
            IEnumerable<DataVertex> vertices = dataGraph.Vertices;

            DataVertex root = GetVertexBySymbol(vertices, new Start().Symbol);
            DataVertex target = GetVertexBySymbol(vertices, new Quit().Symbol);

            // compute shortest paths
            TryFunc<DataVertex, IEnumerable<TEdge>> tryGetPaths = dataGraph.ShortestPathsDijkstra(_edgeCost, root);

            tryGetPaths(target, out IEnumerable<TEdge> path);
            return path;
        }

        private DataVertex GetVertexBySymbol(IEnumerable<DataVertex> vertices, char symbol)
        {
            return vertices.First(x => x.Symbol == symbol);
        }
    }
}
