using PassingMazesAlgorithm.Core.Reader.Tokenizers.Models;

namespace PassingMazesAlgorithm.Core.Reader.Parsers
{
    internal class MapDimensionsParser
    {
        public int Width { get; }
        public int Height { get; }

        public (int width, int height) Dimensions
        {
            get { return (Width, Height); }
        }

        public MapDimensionsParser(MapDimensionsToken mapDimensions)
        {
            if (int.TryParse(mapDimensions.Width, out int width))
            {
                Width = width;
            }

            if (int.TryParse(mapDimensions.Height, out int height))
            {
                Height = height;
            }
        }

        public bool IsValid
        {
            get
            {
                return Width >= mMinSize && Height >= mMinSize;
            }
        }

        private readonly int mMinSize = 4;
    }
}
