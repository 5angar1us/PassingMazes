using System;

namespace PassingMazesAlgorithm.Core
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
