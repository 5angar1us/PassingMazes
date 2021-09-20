using QuickGraph.Algorithms.Search;
using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace solution
{
    class EdgeOptimizer
    {
        public IEnumerable<OptimazedDataEdge> GetOptimazedDataEdges(DataGraph dataGraph, List<DataVertex> keyVertices)
        {
            this.keyVertices = keyVertices;

            var dfs = new DepthFirstSearchAlgorithm<DataVertex, DataEdge>(dataGraph);
            dfs.DiscoverVertex += Dfs_DiscoverVertex;
            dfs.FinishVertex += Dfs_FinishVertex;
            dfs.TreeEdge += Dfs_TreeEdge;

            dfs.Compute();

            return dataEdges;
        }

        private readonly List<OptimazedDataEdge> dataEdges = new List<OptimazedDataEdge>();
        private IEnumerable<DataVertex> keyVertices;
       
        private DataVertex firstKeyVertex;
        private readonly TurnExpert turnNeighbor = new TurnExpert();

        private int PassedNonKeyPeaksCounter = 0;

        private void Dfs_FinishVertex(DataVertex vertex)
        {
            firstKeyVertex = null;
        }

        private void Dfs_TreeEdge(DataEdge e)
        {
            DataVertex source = e.Source;
            DataVertex target = e.Target;
            if (keyVertices.Contains(source) && firstKeyVertex == null)
            {
                firstKeyVertex = source;
                PassedNonKeyPeaksCounter = 0;
            }

            PassedNonKeyPeaksCounter++;

            if (keyVertices.Contains(target))
            {
                OptimazedDataEdge edge = CreateEdge(firstKeyVertex, target, e.NeighborSide, PassedNonKeyPeaksCounter);
                dataEdges.Add(edge);

                OptimazedDataEdge revercedEdge = CreateEdge(target, firstKeyVertex, turnNeighbor.GetOppositENeighborSide(e.NeighborSide), PassedNonKeyPeaksCounter);
                dataEdges.Add(revercedEdge);

                firstKeyVertex = null;
            }
        }

        private OptimazedDataEdge CreateEdge
            (
                DataVertex source,
                DataVertex target,
                ENeighborSide eNeighborSide,
                int passedNonKeyPeaksCounter
            )
        {
            string textFormat = $"{source.Name}->{target.Name}";

            return new OptimazedDataEdge(source, target)
            {
                Text = textFormat,
                NeighborSide = eNeighborSide,
                Count = passedNonKeyPeaksCounter
            };
        }

        private void Dfs_DiscoverVertex(DataVertex vertex)
        {
        }
    }
}
