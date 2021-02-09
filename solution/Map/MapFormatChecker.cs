using solution.Map;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace solution
{
    class MapFormatChecker
    {
        const int minMapSize = 10;
        const int maxMapSize = 50;

        public void CheckMapDimensions(int[] mapDimensions)
        {
            if (mapDimensions.Count() != 2)
                throw new MapFormatException("The size of the map does not match the format");

            if (mapDimensions.Any(x => x < 0))
                throw new MapFormatException("Map dimensions contain negative values");

            if (mapDimensions.Any(x => x > maxMapSize)
                || mapDimensions.Any(x => x < minMapSize))
                throw new MapFormatException("Map dimensions contain incorrect values");
        }

        public void CheckMapBody(int height, int width, IEnumerable<IEnumerable<char>> mapSymbols)
        {
            if (mapSymbols.Count() != height)
                throw new MapFormatException("The number of lines of the map body does not match the specified");

            if (mapSymbols.Any(x => x.Count() != width))
            {
                var indeсes = mapSymbols
                    .Select((symbols, index) => new { symbols, index })
                    .Where(x => x.symbols.Count() != width)
                    .Select(x => x.index);

                throw new MapFormatException($"The number of columns in rows {indeсes} of the card body does not match the specified one");
            }

            CheckMapSymbols(mapSymbols);

            CheckMapBorder(height, width, mapSymbols);

        }

        private static void CheckMapBorder(int height, int width, IEnumerable<IEnumerable<char>> mapSymbols)
        {
            var rowIndeces = new int[] { 0, height - 1 };
            var columnIndeces = new int[] { 0, width - 1 };

            var indexedСells = mapSymbols.Select((mapObject, rowIndex) => new { mapObject, rowIndex })
                .Select(x =>
                {
                    return x.mapObject.Select(
                        (mapObject, columnIndex) => new { mapObject, x.rowIndex, columnIndex });
                })
                .SelectMany(x => x);

            var cellsFromRows = indexedСells.Where(x => rowIndeces.Contains(x.rowIndex));
            var cellsFromColumns = indexedСells.Where(x => columnIndeces.Contains(x.columnIndex));

            var sideObjects = cellsFromRows.Union(cellsFromColumns)
                .Select(x => x.mapObject);

            var wallSymbol = new Wall().Symbol;

            if (sideObjects.Any(x => !x.Equals(wallSymbol)))
                throw new MapFormatException("Map border is not closed");
        }

        private static void CheckMapSymbols(IEnumerable<IEnumerable<char>> mapSymbols)
        {
            var groupedСharacters = mapSymbols
                            .SelectMany(x => x)
                            .GroupBy(x => x)
                            .Select(x => x.Key);

            if (groupedСharacters.Any(x => !MapObjectsFactories.MapObjectsSymbols.Contains(x)))
                throw new MapFormatException("The body of the card does not match the format");
        }
    }
}
