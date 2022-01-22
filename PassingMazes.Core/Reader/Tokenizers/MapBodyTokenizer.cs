using System.Collections.Generic;
using System.Linq;

namespace PassingMazesAlgorithm.Reader.Tokenizers
{
    internal class MapBodyTokenizer
    {
        public IEnumerable<IEnumerable<string>> Values { get; private set; }

        public MapBodyTokenizer(string line)
        {
            Values = line.Split("\n")
                .AsEnumerable()
                .Select(x =>
                {
                    return x.Split(" ").AsEnumerable();
                });
        }
    }
}