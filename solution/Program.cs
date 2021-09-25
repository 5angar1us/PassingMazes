using solution.Converters;
using solution.Graph.Model;
using solution.GameMap.Model;
using solution.Parsers;
using solution.Report;
using System;
using System.IO;

namespace solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var textMap = "";

            var soucePath = @"D:\1.Developing\С#\PassingMazesAlgorithm\solution\Properties\TextFile1.txt";

            using (var sr = new StreamReader(soucePath))
            {
                textMap = sr.ReadToEnd();
            }

            var parser = new MapParser(new MapFormatChecker());
            Map map = parser.Parse(textMap);

            var mapConverter = new MapConverter();
            DataGraph graph = mapConverter.ToGraph(map);

            GraphOptimazer graphOptimazer = new GraphOptimazer();
            OptimazedDataGraph optimazedGraph = graphOptimazer.Optimaze(graph);

 

            var pathInterpreter = new PathInterpreter();

            (string optimazedCommands, string optimazedEdgeOrder) 
                = pathInterpreter.Interpriate(
                    new OptimazedCommadFormater(), 
                    new EdgeInfoFormater<OptimazedDataEdge>(), 
                    new PathFinder<OptimazedDataGraph, 
                    OptimazedDataEdge>(optimazedGraph)
                );

            (string commands, string edgeOrder) = pathInterpreter.Interpriate(new DataCommandFormater(), new EdgeInfoFormater<DataEdge>(), new PathFinder<DataGraph, DataEdge>(graph));

            var reportBuilder = new ConsoleReportBuilder();

            reportBuilder.AppendSeparator();
            reportBuilder.AppendSymbols(map);

            reportBuilder.AppendSeparator();
            reportBuilder.AppendMap(map);

            if (optimazedCommands.Equals(commands))
            {
                reportBuilder.AppendMessage("The commands are equals", commands);
                reportBuilder.AppendMessage(nameof(edgeOrder), edgeOrder);
                reportBuilder.AppendMessage(nameof(optimazedEdgeOrder), optimazedEdgeOrder);
            }
            else
            {
                reportBuilder.AppendMessage(nameof(commands), commands);
                reportBuilder.AppendMessage(nameof(edgeOrder), edgeOrder);

                reportBuilder.AppendMessage(nameof(optimazedCommands), optimazedCommands);
                reportBuilder.AppendMessage(nameof(optimazedEdgeOrder), optimazedEdgeOrder);
            }

            reportBuilder.AppendSeparator();

            Console.WriteLine(reportBuilder.GetReport());
        }
    }
}
