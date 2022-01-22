using System;
using PassingMazesAlgorithm.Core.MazeMap.Factories;

namespace PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects
{
    public abstract class MapObject
    {
        public string Name { protected set; get; }
        public char Symbol { protected set; get; }

        protected MapObject(char symbol, int i = -1)
        {
            Symbol = symbol;
            Name = Symbol + i.ToString();
        }

        public override bool Equals(object obj)
        {
            return obj is MapObject @object
                && Equals(@object);
        }

        public bool Equals(MapObject obj)
        {
            return Symbol == obj.Symbol
                && Name == Name;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Name, Symbol);
        }

        public static bool TryParse(string symbol, out MapObject mapObject)
        {
            mapObject = null;

            symbol = symbol.Trim();

            if (symbol == null && symbol.Length == 0) return false;



            return TryParse(symbol[0], out mapObject);
        }

        public static bool TryParse(char symbol, out MapObject mapObject)
        {
            return MapObjectsFactory.TryCreateMapObject(symbol, out mapObject);
        }
    }
}
