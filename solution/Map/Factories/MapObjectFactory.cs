using solution.GameMap.Model.MapObjects;
using System;

namespace solution.GameMap
{
    public class MapObjectFactory<T> : IMapObjectFactory where T : MapObject
    {
        private int counter = 0;
        public MapObject CreateObject() => (MapObject)Activator.CreateInstance(typeof(T), new object[] { counter++ });
    }
}
