using PassingMazesAlgorithm.Core.GameMap.Model.MapObjects;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PassingMazesAlgorithm.Core.GameMap.Model
{
    public class Map
    {
        public int Height { get; }
        public int Width { get; }

        private const int _minSize = 1;
        private MapObject[,] _Cells { get; }

        public MapObject this[int height, int width]
        {
            get
            {
                return _Cells[height, width];
            }
            set
            {
                _Cells[height, width] = value;
            }
        }

        public MapObject this[(int height, int width) tuple]
        {
            get
            {
                return _Cells[tuple.height, tuple.width];
            }
            set
            {
                _Cells[tuple.height, tuple.width] = value;
            }
        }

        public Map(MapData mapData)
        {
            if (mapData.Height < _minSize || mapData.Width < _minSize)
                throw new ArgumentException();

            Height = mapData.Height;
            Width = mapData.Width;

            _Cells = new MapObject[Height, Width];

            var mapObjects = mapData.MapBodySymbols.Select(row => row.Select(cellSymbol => MapObjectsFactory.CreateMapObject(cellSymbol)));
            ReadMapObjects(mapObjects);
        }

        private void ReadMapObjects(IEnumerable<IEnumerable<MapObject>> mapObjects)
        {
            var iterRows = mapObjects.GetEnumerator();

            for (int r = 0; r < _Cells.GetLength(0); r++)
            {
                iterRows.MoveNext();
                var iterCell = iterRows.Current.GetEnumerator();

                for (int c = 0; c < _Cells.GetLength(1); c++)
                {
                    iterCell.MoveNext();

                    _Cells[r, c] = iterCell.Current;
                }
            }
        }
    }
}
