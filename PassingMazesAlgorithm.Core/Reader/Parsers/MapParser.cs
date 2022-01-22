using System;
using System.Collections.Generic;
using PassingMazesAlgorithm.Core.MazeMap.Model;
using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;
using PassingMazesAlgorithm.Core.Reader.Parsers.Models;
using PassingMazesAlgorithm.Core.Reader.Tokenizers.Models;
using PassingMazesAlgorithm.Core.Reader.Validators;

namespace PassingMazesAlgorithm.Core.Reader.Parsers
{
    public class MapParser
    {

        public MapParser()
        {

        }

        public Maze Parse(MapTokens map)
        {
            var mapDimensions = ParseDimensions(map.MapDimensions);
            var mapBody = ParseMapBody(map.MapBodyValues);


            MapValidator mapValidator = new MapValidator();
            if (!mapValidator.Validate(mapBody, mapDimensions))
            {
                throw new Exception("Map validation has been fail");
            }

            return new Maze(mapBody, mapDimensions);
        }



        private MapDimensions ParseDimensions(MapDimensionsToken mapDimensionsToken)
        {
            var mapDimensionsParsing = new MapDimensionsParser(mapDimensionsToken);
            if (!mapDimensionsParsing.IsValid)
            {
                throw new Exception("Invalid map dimensions values");
            }
            return new MapDimensions(mapDimensionsParsing.Dimensions);
        }

        private IEnumerable<IEnumerable<MapObject>> ParseMapBody(IEnumerable<IEnumerable<string>> values)
        {
            var mapBodyParsing = new MapBodyParser(values);
            if (!mapBodyParsing.IsValid)
            {
                throw new Exception("Invalid map body");
            }

            return mapBodyParsing.MapObjects;
        }
    }
}
