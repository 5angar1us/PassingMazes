﻿using solution.GameMap.Model.MapObjects;

namespace solution
{
    class Quit : MapObject
    {
        public Quit(int i) : base('Q', i)
        {
        }

        public Quit() : base('Q')
        {
        }
    }
}
