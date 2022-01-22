using System;
using System.Collections.Generic;
using System.Linq;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;
using PassingMazesAlgorithm.Core.Reader.Parsers.Models;

namespace PassingMazesAlgorithm.Core.Reader.Validators
{
    public class MapValidator
    {
        private IEnumerable<IEnumerable<MapObject>> mapObjects;
        private MapDimensions mapDimensions;

        public MapValidator()
        {

        }

        public bool Validate(IEnumerable<IEnumerable<MapObject>> mapObjects, MapDimensions mapDimensions)
        {
            this.mapObjects = mapObjects;
            this.mapDimensions = mapDimensions;

            return IsHeightCurrect()
                && IsWidthCurrect()
                && IsMapBordersClosed();
        }

        private bool IsHeightCurrect()
        {
            return mapObjects.Count() == mapDimensions.Height;
            //throw new MapFormatException("The number of lines of the map body does not match the specified");
        }

        private bool IsWidthCurrect()
        {
            return mapObjects.Any(x => x.Count() == mapDimensions.Width);

            //var indeсes = mapObjects
            //    .Select((symbols, index) => new { symbols, index })
            //    .Where(x => x.symbols.Count() != mapDimensions.Width)
            //    .Select(x => x.index);

            //throw new MapFormatException($"The number of columns in rows {indeсes} of the card body does not match the specified one");

        }

        private bool IsMapBordersClosed()
        {
            IEnumerable<char> borderObjectSymbols = GetborderObjectSymbols(mapObjects);

            char wallSymbol = new Wall().Symbol;
            //throw new MapFormatException("Map border is not closed");

            return borderObjectSymbols.All(x => x.Equals(wallSymbol));
        }

        private IEnumerable<char> GetborderObjectSymbols(IEnumerable<IEnumerable<MapObject>> mapObjects)
        {
            var rowBorderIndeces = new int[] { 0, mapDimensions.Height - 1 };
            var columnBorderIndeces = new int[] { 0, mapDimensions.Width - 1 };

            var indexedСells = mapObjects
                .Select((row, rowIndex) => (row, rowIndex))
                .Select(x => x.row.Select((MapObject item, int columnIndex) => (cellSymbol: item.Symbol, x.rowIndex, columnIndex)))
                .SelectMany(x => x);

            var rowBorderCells = indexedСells.Where(x => rowBorderIndeces.Contains(x.rowIndex));
            var columnBorderCells = indexedСells.Where(x => columnBorderIndeces.Contains(x.columnIndex));

            return rowBorderCells
                .Union(columnBorderCells)
                .Select(x => x.cellSymbol);
        }

    }
}
