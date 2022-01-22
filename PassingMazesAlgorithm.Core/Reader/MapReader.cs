using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.Reader.Parsers;

namespace PassingMazesAlgorithm.Core.Reader.Tokenizers
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