using System;
using System.Collections.Generic;
using System.Text;

namespace solution.Map.Model.MapObjects
{
    class Wall : MapObject
    {
        public Wall(int i) : base('X', i)
        {

        }

        public Wall() : base('X')
        {

        }
    }
}
