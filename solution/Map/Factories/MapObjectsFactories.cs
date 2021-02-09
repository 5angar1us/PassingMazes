using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace solution.Map
{
    public class MapObjectsFactories
    {

        public static ReadOnlyCollection<MapObjectFactory> mapObjectFactories = new List<MapObjectFactory>
        {
            new MapObjectFactory<Wall>(),
            new MapObjectFactory<Floor>(),
            new MapObjectFactory<Start>(),
            new MapObjectFactory<Quit>()
        }.AsReadOnly();

        public static ReadOnlyCollection<MapObject> MapObjects { get; } = mapObjectFactories.Select(x => x.CreateObject()).ToList().AsReadOnly();

        public static ReadOnlyCollection<char> MapObjectsSymbols { get; } = MapObjects.Select(x => x.Symbol).ToList().AsReadOnly();

        static public MapObject CreateMapObject(char symbol)
        {
            for (int i = 0; i < mapObjectFactories.Count; i++)
            {
                var x = MapObjects[i];

                if (x.EqualsBySybmol(symbol))
                    return mapObjectFactories[i].CreateObject();
            }

            throw new ArgumentException("Invalid character of map object");
        }
    }
}
