namespace PassingMazesAlgorithm.Core.Reader.Tokenizers
{
    public class MapDimensionsTokenizer
    {

        public string Width { get; }
        public string Height { get; }

        public (string width, string height) Dimensions
        {
            get
            {
                return (Width, Height);
            }
        }

        public MapDimensionsTokenizer(string line)
        {
            var firstSpace = line.IndexOf(" ");

            Width = line.Substring(0, firstSpace);
            Height = line.Substring(firstSpace + 1);
        }
    }
}
