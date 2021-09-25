using System.Collections.Generic;

namespace solution.GameMap.Model
{
    public class MapData
    {
        public IEnumerable<IEnumerable<char>> MapBodySymbols { set; get; }
        public int Height { set; get; }
        public int Width { set; get; }
    }
}
