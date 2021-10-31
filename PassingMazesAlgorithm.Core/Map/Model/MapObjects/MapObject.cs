using System;

namespace PassingMazesAlgorithm.Core.GameMap.Model.MapObjects
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
    }
}
