using solution.Converters.NearestIndexes.Model;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace solution.Converters.NearestIndexes
{
    class NearestIndexConvertersFactory
    {
        public static List<IDataNearestIndices> NearestIndiceConvertors { get; } = new List<IDataNearestIndices>()
        {
            new LeftNearestIndices(),
            new TopNearestIndices(),
            new RightNearestIndices(),
            new BottomNearestIndices()
        };

    }
}
