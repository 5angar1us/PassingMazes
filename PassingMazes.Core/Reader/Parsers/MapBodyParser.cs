using System.Collections.Generic;
using System.Linq;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core.Reader.Parsers
{
    internal class MapBodyParser
    {
        public IEnumerable<IEnumerable<MapObject>> MapObjects { get; }

        public MapBodyParser(IEnumerable<IEnumerable<string>> values)
        {

            IEnumerable<IEnumerable<(bool isValid, MapObject mapObject)>> mapObjectParseResult = values.Select(row =>
            {
                return row.Select(symbol =>
                 {
                     bool isValid = MapObject.TryParse(symbol, out MapObject mapObject);
                     return (isValid, mapObject);
                 });
            });

            isValidObjects = mapObjectParseResult.Select(row =>
            {
                return row.Select(item =>
                {
                    return item.isValid;
                });
            });

            MapObjects = mapObjectParseResult.Select(row =>
            {
                return row.Select(item =>
                {
                    return item.mapObject;
                });
            });

            isValidObjects = isValidObjects.ToList();
        }

        public bool IsValid
        {
            get
            {
                bool isAllParsed = isValidObjects.SelectMany(x => x).All(x => x == true);
                return isAllParsed;
            }
        }
        private readonly IEnumerable<IEnumerable<bool>> isValidObjects;

    }
}
