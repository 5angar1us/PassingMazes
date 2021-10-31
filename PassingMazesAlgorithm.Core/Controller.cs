using QuickGraph;
using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.GameMap.Model;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace PassingMazesAlgorithm.Core
{
    public class Controller
    {
        public IEnumerable<DataEdge> Run(string textMap)
        {
            var parser = new MapParser(new MapFormatChecker());
            Map map = parser.Parse(textMap);

            var mapConverter = new MapConverter();
            DataGraph graph = mapConverter.ToGraph(map);


            var pathFinder = new PathFinder<DataGraph, DataEdge>(graph);
            IEnumerable<DataEdge> path = pathFinder.Find();
            return path;
        }
    }
}
