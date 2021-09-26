using NUnit.Framework;
using solution.GameMap.Model;
using solution.Graph.Model;
using solution.Parsers;
using System.Text;

namespace solution.Test
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
        public void EqualGame()
        {
            var game = new Game();
            var path = game.Run(maze);

            var optimazedGame = new OptimazedGame();
            var optimazedPath = optimazedGame.Run(maze);

            var pathInterpreter = new PathInterpreter();

            string optimazedCommands = pathInterpreter.Interpriate(new OptimazedDataCommadFormater(), optimazedPath);
            string commands = pathInterpreter.Interpriate(new DataCommandFormater(), path);

            Assert.Equals(optimazedCommands, commands);
        }

        public void EqualMap()
        {
            var parser = new MapParser(new MapFormatChecker());
            Map map = parser.Parse(maze);
            var textMap = ReadMap(map);

            Assert.Equals(maze, textMap);
        }

        private string ReadMap(Map map)
        {
            var sb = new StringBuilder();
            for (int r = 0; r < map.Height; r++)
            {
                for (int c = 0; c < map.Width; c++)
                {
                    sb.Append(map[r, c].Symbol).Append(' ');
                }
                sb.AppendLine();
            }
            return sb.ToString();
        }

    }
}