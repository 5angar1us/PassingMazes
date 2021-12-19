using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PassingMazesAlgorithm.Core.GameMap.Model
{
    public static class MapExtentions
    {
        private static Action<int> _emptyAction = (row) => { };

        private static void ProcessFunctionOverData
            (
            Action<int> beforeRowFunc,
            Action<int, int> columnFunc,
            Action<int> afterRowFunc,
            int startRowIndex,
            int endRowIndex,
            int startColumnIndex,
            int endColumnIndex )
        {
            for (var row = startRowIndex; row < endRowIndex; row++)
            {
                beforeRowFunc(row);
                for (var column = startColumnIndex; column < endColumnIndex; column++)
                {
                    columnFunc(row, column);
                }
                afterRowFunc(row);
            }
        }

        public static void ProcessFunctionOverAllData(
            this Map map,
            Action<int> beforeRowFunc,
            Action<int, int> columnFunc,
            Action<int> afterRowFunc)
        {
            ProcessFunctionOverData(beforeRowFunc, columnFunc, afterRowFunc, 0, map.Height, 0, map.Width);
        }

        public static void ProcessFunctionOverNotWallData(
            this Map map,
            Action<int> beforeRowFunc,
            Action<int, int> columnFunc,
            Action<int> afterRowFunc)
        {
            ProcessFunctionOverData(beforeRowFunc, columnFunc, afterRowFunc, 1, map.Height - 1, 1 , map.Width - 1);
        }

        // =========================================================================================
        //
        // Over all data
        //
        // =========================================================================================

        public static void ProcessFunctionOverAllData(this Map map, Action<int, int> columnFunc)
        {
            map.ProcessFunctionOverAllData( _emptyAction, columnFunc, _emptyAction);
        }

        public static void ProcessFunctionOverAllData(this Map map, Action<int> beforeRowFunc, Action<int, int> columnFunc)
        {
            map.ProcessFunctionOverAllData(beforeRowFunc, columnFunc, _emptyAction);
        }

        public static void ProcessFunctionOverAllData(this Map map, Action<int, int> columnFunc, Action<int> afterRowFunc)
        {
            map.ProcessFunctionOverNotWallData(_emptyAction, columnFunc, afterRowFunc);
        }

        // =========================================================================================
        //
        // Over not wall Data
        //
        // =========================================================================================

        public static void ProcessFunctionOverNotWallData(this Map map, Action<int, int> columnFunc)
        {
            map.ProcessFunctionOverNotWallData(_emptyAction, columnFunc, _emptyAction);
        }

        public static void ProcessFunctionOverNotWallData(this Map map, Action<int> beforeRowFunc, Action<int, int> columnFunc)
        {
            map.ProcessFunctionOverNotWallData(beforeRowFunc, columnFunc, _emptyAction);
        }

        public static void ProcessFunctionOverNotWallData(this Map map, Action<int, int> columnFunc, Action<int> afterRowFunc)
        {
            map.ProcessFunctionOverAllData(_emptyAction, columnFunc, afterRowFunc);
        }

        public static (int r, int c) IndexOfCellByName(this Map map, string name)
        {
            for (int i = 0; i < map.Height; i++)
            {
                for (int j = 0; j < map.Width; j++)
                {
                    var el = map[i, j];
                    if (el.Name.Equals(name))
                        return (i, j);
                }
            }
            return (-1, -1);
        }
    }
}
