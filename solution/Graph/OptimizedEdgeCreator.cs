using QuickGraph.Algorithms.Search;
using solution.Graph.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace solution
{
    class OptimizedEdgeCreator
    {
        private List<OptimazedDataEdge> dataEdges = new List<OptimazedDataEdge>();

        private DataVertex FirstKeyVertex { set; get; }
        private int PassedNonKeyPeaksCounter = 0;

        private IEnumerable<DataVertex> KeyVertices { set; get; }

        private TurnNeighborSide turnNeighbor = new TurnNeighborSide();

        public IEnumerable<OptimazedDataEdge> GetOptimazedDataEdges(DataGraph dataGraph, List<DataVertex> keyVertices)
        {
            KeyVertices = keyVertices;

            var dfs = new DepthFirstSearchAlgorithm<DataVertex, DataEdge>(dataGraph);
            dfs.DiscoverVertex += Dfs_DiscoverVertex;
            dfs.FinishVertex += Dfs_FinishVertex;
            dfs.TreeEdge += Dfs_TreeEdge;
            //do the search
            dfs.Compute();

            return dataEdges;
        }

        private void Dfs_FinishVertex(DataVertex vertex)
        {
            FirstKeyVertex = null;

            //endVertexOrder.Add(@$"{vertex.Name}");
        }

        private void Dfs_TreeEdge(DataEdge e)
        {
            var source = e.Source;
            var target = e.Target;
            if (KeyVertices.Contains(source) & FirstKeyVertex == null)
            {
                FirstKeyVertex = source;
                PassedNonKeyPeaksCounter = 0;
              
            }

            PassedNonKeyPeaksCounter++;
            

            if (KeyVertices.Contains(target))
            {
                var edge = CreateEdge(FirstKeyVertex, target, e.NeighborSide, PassedNonKeyPeaksCounter);
                dataEdges.Add(edge);

                var revercedEdge = CreateEdge(target, FirstKeyVertex, turnNeighbor.Turn(e.NeighborSide), PassedNonKeyPeaksCounter);
                dataEdges.Add(revercedEdge);

                FirstKeyVertex = null;
            }

            //edgeTraversalOrder.Add(@$"{e.Text}");
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
            //if (KeyVertices.Contains(vertex))
            //{
            //    keyVertexOrder.Add(@$"{vertex.Name}");
            //}
            //vertexTraversalOrder.Add(@$"{vertex.Name}");
        }
    }
}
