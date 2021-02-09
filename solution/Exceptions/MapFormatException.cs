using System;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    class MapFormatException : Exception
    {
        public MapFormatException()
        {
        }

        public MapFormatException(string message) : base(message)
        {

        }
    }
}
