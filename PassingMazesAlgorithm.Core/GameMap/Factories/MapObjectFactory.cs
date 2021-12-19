using PassingMazesAlgorithm.Core.GameMap.Model.MapObjects;
using System;

namespace PassingMazesAlgorithm.Core.GameMap
{
    public class MapObjectFactory<T> : IMapObjectFactory where T : MapObject
    {
        private int _counter = 0;
        public MapObject CreateObject() => (MapObject)Activator.CreateInstance(typeof(T), new object[] { _counter++ });
    }
}
