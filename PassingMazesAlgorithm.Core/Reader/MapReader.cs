using System.IO;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Reader.Parsers;
using PassingMazesAlgorithm.Core.Reader.Tokenizers;

namespace PassingMazesAlgorithm.Core.Reader
{
    public class MapReader
    {

        public Maze Read(StreamReader stream)
        {

            var mapTokinizer = new MapTokinizer();
            Tokenizers.Models.MapTokens mapTokens = mapTokinizer.ReadMapTokens(stream);


            var mapParser = new MapParser();
            Maze map = mapParser.Parse(mapTokens);

            return map;
        }
    }
}
