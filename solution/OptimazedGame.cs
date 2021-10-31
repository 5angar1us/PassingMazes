using solution.Converters;
using solution.GameMap.Model;
using solution.Graph.Model;
using solution.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    public class OptimazedGame
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
