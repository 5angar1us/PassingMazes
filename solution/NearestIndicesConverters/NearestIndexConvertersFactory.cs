using System.Collections.Generic;

namespace solution
{
    class NearestIndexConvertersFactory
    {
        public static List<DataNearestIndices> NearestIndiceConvertors { private set; get; } = new List<DataNearestIndices>()
        {
            new LeftNearestIndices(),
            new TopNearestIndices(),
            new RightNearestIndices(),
            new BottomNearestIndices()
        };

    }
}
