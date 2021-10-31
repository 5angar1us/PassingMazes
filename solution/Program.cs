using solution.Converters;
using solution.Graph.Model;
using solution.GameMap.Model;
using solution.Parsers;
using solution.Report;
using System;
using System.IO;
using System.Collections.Generic;

namespace solution
{
    class Program
    {
        static void Main(string[] args)
        {
            var maze = @"   10 10
                            X X X X X X X X X X
                            X S . . . . . . . X
                            X X X X X . X X X X
                            X . . . . . X . . X
                            X . X . X X X X . X
                            X . X . . . X X . X
                            X . X X X . . . . X
                            X . X . X . X X X X
                            X . . . X . . . Q X
                            X X X X X X X X X X";

            

            var optimazedController = new OptimazedController();
            IEnumerable<OptimazedDataEdge> optimazedPath = optimazedController.Run(maze);

            var pathInterpreter = new PathInterpreter();

            string optimazedCommands = pathInterpreter.Interpriate(new OptimazedDataCommadFormater(), optimazedPath);
            string optimazedEdgeOrder = pathInterpreter.Interpriate(new EdgeInfoFormater<OptimazedDataEdge>(), optimazedPath);


            var reportBuilder = new ConsoleReportBuilder();

            reportBuilder.AppendMessage("The commands are equals", optimazedCommands);
            reportBuilder.AppendMessage(nameof(optimazedEdgeOrder), optimazedEdgeOrder);

            reportBuilder.AppendSeparator();

            Console.WriteLine(reportBuilder.Build());
        }


    }
}
