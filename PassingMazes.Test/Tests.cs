using System.Collections.Generic;
using System.IO;
using System.Text;
using NUnit.Framework;
using PassingMazesAlgorithm.ConsoleApp.UI;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters;
using PassingMazesAlgorithm.Core.Converters;
using PassingMazesAlgorithm.Core.Graph.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Reader;

namespace PassingMazesAlgorithm.Core.Test
{
    public class Tests
    {
        private readonly string sourceMaze = @"10 10
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

        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void IsCurrectMapReading()
        {
            string sourceMaze = getMaze();
            var stream = new StreamReader(GenerateStreamFromString(sourceMaze));

            var parser = new MapReader();
            Maze map = parser.Read(stream);
            string textMap = ReadMap(map);

            Assert.AreEqual(sourceMaze, textMap);
        }

        [Test]
        public void EqualRoute()
        {
            string sourceMaze = getMaze();
            var stream = new StreamReader(GenerateStreamFromString(sourceMaze));

            var parser = new MapReader();
            Maze maze = parser.Read(stream);

            var pathFinder = new PathFinder(new MapConverter());
            IEnumerable<DataEdge> path = pathFinder.Find(maze);
            var pathInterpreter = new PathHandler();

            string actualRouteCommand = pathInterpreter.Run(new DataCommandFormater(), path);
            const string expectedRouteCommand = "RRRRDDLLDDRRDDDRRR";

            Assert.AreEqual(expectedRouteCommand, actualRouteCommand);
        }

        private string ReadMap(Maze map)
        {
            var sb = new StringBuilder();

            sb.Append(map.Height)
                .Append(" ")
                .Append(map.Width)
                .AppendLine();

            for (int row = 0; row < map.Height; row++)
            {
                for (int column = 0; column < map.Width; column++)
                {
                    sb.Append(map[row, column].Symbol);
                    if (column != map.Width - 1)
                        sb.Append(' ');
                }
                if (row != map.Height - 1)
                    sb.AppendLine();

            }
            return sb.ToString();
        }

        public static string getMaze()
        {
            string maze = PassingMazes.Test.Properties.Resources.Maze1;

            return maze;
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}
