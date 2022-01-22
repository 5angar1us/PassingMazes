using System.Collections.Generic;

namespace PassingMazesAlgorithm.Core.Reader.Tokenizers.Models
{
    public class MapTokens
    {
        public MapTokens(MapDimensionsToken mapDimensionsToken, IEnumerable<IEnumerable<string>> mapBodyValues)
        {
            MapDimensions = mapDimensionsToken;
            MapBodyValues = mapBodyValues;
        }

        public MapDimensionsToken MapDimensions { get; }
        public IEnumerable<IEnumerable<string>> MapBodyValues { get; }
    }
}
