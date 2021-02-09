using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    public class MyMap
    {
        const int minSize = 1;

        public MapObject[,] Cells { private set; get; }

        public int Height { private set; get; }
        public int Width { private set; get; }

        public MapObject this[int height, int width]
        {
            get
            {
                return Cells[height,width];
            }
            set
            {
                Cells[height, width] = value;
            }
        }

        public MyMap(int height, int width)
        {
            if (height < minSize || width < minSize)
                throw new ArgumentException();

            Height = height;
            Width = width;

            Cells = new MapObject[Height, Width];
        }

        public void ProcessFunctionOverData(Action<int, int> func)
        {
            for (var i = 0; i < this.Height; i++)
            {
                for (var j = 0; j < this.Width; j++)
                {
                    func(i, j);
                }
            }
        }

        public (int r, int c) IndexOfCellByName(string name)
        {
            for (int i = 0; i < Cells.GetLength(0); i++)
            {
                for (int j = 0; j < Cells.GetLength(1); j++)
                {
                    var el = Cells[i, j];
                    if (el.Name.Equals(name))
                        return (i, j);
                }
            }
            return (-1, -1);
        }

        public void InitMap(IEnumerable<IEnumerable<MapObject>> mapObjects)
        {
            var iterRows = mapObjects.GetEnumerator();

            for (int r = 0; r < Cells.GetLength(0); r++)
            {
                iterRows.MoveNext();
                var iterCell = iterRows.Current.GetEnumerator();

                for (int c = 0; c < Cells.GetLength(1); c++)
                {
                    iterCell.MoveNext();

                    Cells[r, c] = iterCell.Current;
                }
            }

        }
    }
}
