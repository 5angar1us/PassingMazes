using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.Report;
using System;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.Core
{
    static class Program
    {
        static void Main(string[] args)
        {
            var sourceMaze = @"   10 10
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

            var maze = new Maze();
            IEnumerable<DataEdge> path = maze.FindWay(sourceMaze);

            var pathInterpreter = new PathInterpreter();

            string commands = pathInterpreter.Interpriate(new DataCommandFormater(), path);
            string edgeOrder = pathInterpreter.Interpriate(new EdgeInfoFormater<DataEdge>(), path);

            var reportBuilder = new ConsoleReportBuilder();

            reportBuilder.AppendMessage("The commands are equals", commands);
            reportBuilder.AppendMessage(nameof(edgeOrder), edgeOrder);

            reportBuilder.AppendSeparator();

            Console.WriteLine(reportBuilder.Build());
        }

    }
}
