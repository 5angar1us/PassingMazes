using NUnit.Framework;
using PassingMazesAlgorithm.ConsoleApp.UI;
using PassingMazesAlgorithm.ConsoleApp.UI.ConsoleCommandFormaters;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Parsers;
using System.Text;

namespace PassingMazesAlgorithm.Core.Test
{
    public class Tests
    {
        private readonly string sourceMaze = @" 10 10
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
        public void EqualMap()
        {
            var parser = new MapParser(new MapFormatChecker());
            Map map = parser.Parse(sourceMaze);
            var textMap = ReadMap(map);

            Assert.AreEqual(sourceMaze.Trim(), textMap);
        }

        [Test]
        public void EqualRoute()
        {
            var maze = new Maze();
            var path = maze.FindWay(sourceMaze);
            var pathInterpreter = new PathInterpreter();

            string actualRouteCommand = pathInterpreter.Interpriate(new DataCommandFormater(), path);
            const string expectedRouteCommand = "RRRRDDLLDDRRDDDRRR";

            Assert.AreEqual(expectedRouteCommand, actualRouteCommand);
        }

        private string ReadMap(Map map)
        {
            var sb = new StringBuilder();
            var space = "                                          ";

            sb.Append(map.Height)
                .Append(" ")
                .Append(map.Width)
                .AppendLine()
                .Append(space);

            for (int row = 0; row < map.Height; row++)
            {
                for (int column = 0; column < map.Width; column++)
                {
                    sb.Append(map[row, column].Symbol);
                    if (column != map.Width - 1)
                        sb.Append(' ');
                }
                if (row != map.Height - 1)
                    sb.AppendLine().Append(space);

            }
            return sb.ToString();
        }
    }
}