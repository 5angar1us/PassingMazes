using System.Collections.Generic;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;
using PassingMazesAlgorithm.Core.Reader.Parsers.Models;

namespace PassingMazesAlgorithm.Core.MazeMap.Model
{
    public class Maze
    {

        public int Height { get; }
        public int Width { get; }

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

        public Maze()
        {

        }

        public Maze(IEnumerable<IEnumerable<MapObject>> mapObjects, MapDimensions mapDimensions)
        {
            Height = mapDimensions.Height;
            Width = mapDimensions.Width;

            _Cells = new MapObject[Height, Width];

            ReadMapObjects(mapObjects);
        }

        private void ReadMapObjects(IEnumerable<IEnumerable<MapObject>> mapObjects)
        {
            IEnumerator<IEnumerable<MapObject>> iterRows = mapObjects.GetEnumerator();

            for (int row = 0; row < _Cells.GetLength(0); row++)
            {
                iterRows.MoveNext();
                IEnumerator<MapObject> iterCell = iterRows.Current.GetEnumerator();

                for (int cell = 0; cell < _Cells.GetLength(1); cell++)
                {
                    iterCell.MoveNext();

                    _Cells[row, cell] = iterCell.Current;
                }
            }
        }
    }
}
