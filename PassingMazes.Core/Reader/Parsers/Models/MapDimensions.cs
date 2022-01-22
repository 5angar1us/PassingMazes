namespace PassingMazesAlgorithm.Core.Reader.Parsers.Models
{
    public class MapDimensions
    {
        public MapDimensions(int width, int height)
        {
            Width = width;
            Height = height;
        }

        public MapDimensions((int width, int height) dimensions)
        {
            (Width, Height) = dimensions;
        }

        public int Width { get; }
        public int Height { get; }
    }
}
