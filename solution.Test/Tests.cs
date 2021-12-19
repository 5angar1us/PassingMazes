using NUnit.Framework;
using PassingMazesAlgorithm.Core.GameMap.Model;
using PassingMazesAlgorithm.Core.Parsers;
using System.Text;

namespace PassingMazesAlgorithm.Core.Test
{
    public class Tests
    {
        private readonly string maze = @" 10 10
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
            Map map = parser.Parse(maze);
            var textMap = ReadMap(map);

            Assert.AreEqual(maze.Trim(), textMap);
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

            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    sb.Append(map[r, c].Symbol);
                    if (c != map.Width - 1)
                        sb.Append(' ');
                }
                if (r != map.Height - 1)
                    sb.AppendLine().Append(space);


            }
            return sb.ToString();
        }

    }
}