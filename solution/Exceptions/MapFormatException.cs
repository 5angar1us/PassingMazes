using System;

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
