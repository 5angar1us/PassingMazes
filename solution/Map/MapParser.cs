using solution.Map;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace solution
{
    class MapParser
    {


        public MyMap Parse(string textMap)
        {
            if (textMap.Trim().Length == 0)
                throw new ArgumentException();

            var formatChecker = new MapFormatChecker();

            var textMapRows = textMap.Split(Environment.NewLine);

            var textMapDimensions = textMapRows.First();
            int[] mapDimensions = GetMapDimensions(textMapDimensions);

            formatChecker.CheckMapDimensions(mapDimensions);

            var height = mapDimensions[0];
            var width = mapDimensions[1];

            var mapBody = textMapRows.Skip(1);
            var mapSymbols = GetMapSymbols(mapBody);

            formatChecker.CheckMapBody(height, width, mapSymbols);

            var mapObjects = mapSymbols
                .Select(x =>
                {
                    return x.Select(o => MapObjectsFactories.CreateMapObject(o));
                });

            var map = new MyMap(height, width);
            map.InitMap(mapObjects);

            return map;
        }

        private static IEnumerable<IEnumerable<char>> GetMapSymbols(IEnumerable<string> mapBody)
        {
            return mapBody
              .Select(x =>
              {
                  return x.Split(" ")
                   .Select(x => x)
                   .Select(x => char.Parse(x));
              });
        }

        private static int[] GetMapDimensions(string textMapDimensions)
        {
            return textMapDimensions
                .Split(" ")
                .Select(x =>
                {
                    return new
                    {
                        parsed = int.TryParse(x.ToString(), out int dimension), 
                        dimension
                    };
                })
                .Where(x => x.parsed)
                .Select(x => x.dimension)
                .ToArray();
        }

    }
}
