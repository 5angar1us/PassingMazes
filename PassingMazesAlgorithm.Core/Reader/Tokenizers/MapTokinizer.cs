using System.Collections.Generic;
using System.IO;
using PassingMazesAlgorithm.Core.Reader.Tokenizers.Models;
using PassingMazesAlgorithm.Reader.Tokenizers;

namespace PassingMazesAlgorithm.Core.Reader.Tokenizers
{
    public class MapTokinizer
    {
        public MapTokens ReadMapTokens(StreamReader stream)
        {
            var mapDimensions = ReadMapDimensions(stream);

            var mapBodyValues = ReadMapBody(stream);

            return new MapTokens(mapDimensions, mapBodyValues);
        }


        private IEnumerable<IEnumerable<string>> ReadMapBody(StreamReader stream)
        {
            var values = stream.ReadToEnd();

            var mapBodyTokenizing = new MapBodyTokenizer(values);

            return mapBodyTokenizing.Values;
        }

        private MapDimensionsToken ReadMapDimensions(StreamReader stream)
        {
            var currentLine = stream.ReadLine();
            var mapDimensionsParsing = new MapDimensionsTokenizer(currentLine);

            return new MapDimensionsToken(mapDimensionsParsing.Dimensions);
        }
    }
}
