using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    public abstract class MapObject
    {
        protected MapObject(char symbol, int i = -1)
        {
            Symbol = symbol;
            Name = Symbol + i.ToString();
        }


        public string Name { protected set; get; }
        public char Symbol { protected set; get; }

        public override string ToString()
        {
            return Name.ToString();
        }

        public bool EqualsBySybmol(char s)
        {
            return Symbol.Equals(s);
        }

        public bool EqualsBySybmol(MapObject mapObject)
        {
            return Symbol.Equals(mapObject.Symbol);
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
            return Symbol.GetHashCode() + base.GetHashCode();
        }
    }


}
