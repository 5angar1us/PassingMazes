using QuickGraph;
using solution.Converters;
using solution.GameMap.Model;
using solution.Graph.Model;
using solution.Parsers;
using System;
using System.Collections.Generic;
using System.Text;

namespace solution
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
