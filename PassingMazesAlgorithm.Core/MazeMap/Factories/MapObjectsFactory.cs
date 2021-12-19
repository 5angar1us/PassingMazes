using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;

namespace PassingMazesAlgorithm.Core.MazeMap.Factories
{
    public static class MapObjectsFactory
    {
        public static ReadOnlyCollection<MapObject> MapObjects { get; }
        public static ReadOnlyCollection<char> MapObjectsSymbols { get; }

        static MapObjectsFactory()
        {
            MapObjects = mapObjectFactories.Select(x => x.CreateObject()).ToList().AsReadOnly();
            MapObjectsSymbols = MapObjects.Select(x => x.Symbol).ToList().AsReadOnly();
        }

        public static ReadOnlyCollection<IMapObjectFactory> mapObjectFactories = new List<IMapObjectFactory>
        {
            new MapObjectFactory<Wall>(),
            new MapObjectFactory<Floor>(),
            new MapObjectFactory<Start>(),
            new MapObjectFactory<Quit>()
        }.AsReadOnly();



        static public MapObject CreateMapObject(char symbol)
        {
            for (int i = 0; i < mapObjectFactories.Count; i++)
            {
                MapObject x = MapObjects[i];

                if (x.Symbol.Equals(symbol))
                    return mapObjectFactories[i].CreateObject();
            }

            throw new ArgumentException("Invalid character of map object");
        }
    }
}
