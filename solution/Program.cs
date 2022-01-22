using System;
using System.Collections.Generic;
using PassingMazesAlgorithm.ConsoleApp.UI;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters.Report;
using PassingMazesAlgorithm.Core;
using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Reader;

namespace PassingMazesAlgorithm.ConsoleApp
{
    static class Program
    {
        static void Main(string[] args)
        {
            var mapReader = new MapFileReader(args[0]);

            Maze maze = mapReader.Read();

            var pathFinder = new PathFinder(new MapConverter());
            IEnumerable<DataEdge> path = pathFinder.Find(maze);

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
