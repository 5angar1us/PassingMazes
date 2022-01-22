using System;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core.MazeMap.Factories
{
    public class MapObjectFactory<T> : IMapObjectFactory where T : MapObject
    {
        private int _counter = 0;
        public MapObject CreateObject() => (MapObject)Activator.CreateInstance(typeof(T), new object[] { _counter++ });
    }
}
