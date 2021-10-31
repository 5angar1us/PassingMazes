using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.GameMap.Model;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassingMazesAlgorithm.Core
{
    public class OptimazedController
    {

        public IEnumerable<OptimazedDataEdge> Run(string textMap)
        {
            var parser = new MapParser(new MapFormatChecker());
            Map map = parser.Parse(textMap);

            var mapConverter = new MapConverter();
            DataGraph graph = mapConverter.ToGraph(map);

            GraphOptimazer graphOptimazer = new GraphOptimazer();
            OptimazedDataGraph optimazedGraph = graphOptimazer.Optimaze(graph);

            var optimazedPathFinder = new PathFinder<OptimazedDataGraph, OptimazedDataEdge>(optimazedGraph);
            IEnumerable<OptimazedDataEdge> optimazedPath = optimazedPathFinder.Find();

            return optimazedPath;
        }

    }
}
