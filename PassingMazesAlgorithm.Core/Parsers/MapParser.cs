using PassingMazesAlgorithm.Core.GameMap.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassingMazesAlgorithm.Core.Parsers
{
    public class MapParser
    {

        private MapFormatChecker _formatChecker;

        private const int _minMapSize = 10;
        private const int _maxMapSize = 50;

        public MapParser(MapFormatChecker formatChecker)
        {
            _formatChecker = formatChecker;
        }

        public Map Parse(string textMapData)
        {
            if (textMapData.Trim().Length == 0)
                throw new ArgumentException();

            var mapData = ParseMapData(textMapData);

            return new Map(mapData);
        }

        private MapData ParseMapData(string text)
        {
            string[] textRows = text.Split(Environment.NewLine);

            (int height, int width) = ParseMapDimensions(GetMapDimensions(textRows));
            IEnumerable<IEnumerable<char>> mapBodySymbols = ParseMapBodySymbols(GetMapBody(textRows));

            var mapData = new MapData()
            {
                MapBodySymbols = mapBodySymbols,
                Height = height,
                Width = width
            };

            _formatChecker.CheckBody(mapData);

            return mapData;
        }

        private string GetMapDimensions(IEnumerable<string> textRows) => textRows.First();
        private IEnumerable<string> GetMapBody(IEnumerable<string> textRows) => textRows.Skip(1);

        private IEnumerable<IEnumerable<char>> ParseMapBodySymbols(IEnumerable<string> mapBody)
        {
            return mapBody
              .Select(x =>
              {
                  return x.Trim()
                   .Split(" ")
                   .Select(x => x)
                   .Select(x => char.Parse(x));
              });
        }

        private (int height, int width) ParseMapDimensions(string mapDimensions)
        {
            var mapDimensionsParser = new MapDimensionsParser(_maxMapSize, _minMapSize);

            return mapDimensionsParser.Parse(mapDimensions);
        }
    }
}
