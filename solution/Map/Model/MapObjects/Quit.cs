using System;
using System.Collections.Generic;
using System.Text;

namespace solution.Map.Model.MapObjects
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
