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

        public MapReader(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("File is not defined");
            }

            if (!File.Exists(file))
            {
                throw new FileNotFoundException("Las file does not found", file);
            }

            mFileName = file;
        }

        private string mFileName;

        public Maze Read()
        {
            //var stream = new StreamReader(mFileName);
            var stream = new StreamReader(GenerateStreamFromString(getMaze()));

            var mapTokinizer = new MapTokinizer();
            var mapTokens = mapTokinizer.ReadMapTokens(stream);


            var mapParser = new MapParser();
            var map = mapParser.Parse(mapTokens);

            return map;
        }

        public static string getMaze()
        {
            var sourceMaze = new List<string>()
            {
                "10 10",
                "X X X X X X X X X X",
                "X S . . . . . . . X",
                "X X X X X . X X X X",
                "X . . . . . X . . X",
                "X . X . X X X X . X",
                "X . X . . . X X . X",
                "X . X X X . . . . X",
                "X . X . X . X X X X",
                "X . . . X . . . Q X",
                "X X X X X X X X X X"
            };

            var sb = new StringBuilder();
            sourceMaze.ForEach(x => sb.AppendLine(x));


            return sb.ToString();
        }

        public static MemoryStream GenerateStreamFromString(string value)
        {
            return new MemoryStream(Encoding.UTF8.GetBytes(value ?? ""));
        }
    }
}