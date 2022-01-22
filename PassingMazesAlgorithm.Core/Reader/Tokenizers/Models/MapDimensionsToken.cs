namespace PassingMazesAlgorithm.Core.Reader.Tokenizers.Models
{
    public class MapDimensionsToken
    {
        public MapDimensionsToken(string width, string height)
        {
            Width = width;
            Height = height;
        }

        public MapDimensionsToken((string width, string height) dimensions)
        {
            (Width, Height) = dimensions;
        }

        public string Width { get; }
        public string Height { get; }


    }
}
