using PassingMazesAlgorithm.ConsoleApp.UI;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Report;
using PassingMazesAlgorithm.Core;
using PassingMazesAlgorithm.Core.Graph.Model;
using System.Collections.Generic;
using System;

namespace PassingMazesAlgorithm.ConsoleApp
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

            var pathHandler = new PathHandler();

            string commands = pathHandler.Run(new DataCommandFormater(), path);
            string edgeOrder = pathHandler.Run(new EdgeInfoFormater<DataEdge>(), path);

            var reportBuilder = new ConsoleReportBuilder();

            reportBuilder.AppendMessage("The commands", commands);
            reportBuilder.AppendMessage(nameof(edgeOrder), edgeOrder);

            reportBuilder.AppendSeparator();

            Console.WriteLine(reportBuilder.Build());
        }

    }
}
