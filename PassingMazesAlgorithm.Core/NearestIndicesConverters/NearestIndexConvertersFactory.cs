using PassingMazesAlgorithm.Core.NearestIndicesConverters.Model;
using System.Collections.Generic;

namespace PassingMazesAlgorithm.Core.NearestIndicesConverters
{
    internal static class NearestIndexConvertersFactory
    {
        static NearestIndexConvertersFactory()
        {
            NearestIndiceConvertors = new List<IDataNearestIndices>()
            {
                new LeftNearestIndices(),
                new TopNearestIndices(),
                new RightNearestIndices(),
                new BottomNearestIndices()
            };
        }

        public static IEnumerable<IDataNearestIndices> NearestIndiceConvertors { get; }
    }
}

