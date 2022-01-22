using System.Collections.Generic;
using PassingMazesAlgorithm.Core.NearestIndicesConverters.Model;

namespace PassingMazesAlgorithm.Core.NearestIndicesConverters
{
    public class NearestIndexConvertersFactory
    {
        public NearestIndexConvertersFactory()
        {
            NearestIndiceConvertors = new List<IDataNearestIndices>()
            {
                new LeftNearestIndices(),
                new TopNearestIndices(),
                new RightNearestIndices(),
                new BottomNearestIndices()
            };
        }

        public IEnumerable<IDataNearestIndices> NearestIndiceConvertors { get; }
    }
}

