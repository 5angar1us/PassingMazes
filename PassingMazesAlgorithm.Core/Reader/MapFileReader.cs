using System;
using System.IO;
using PassingMazesAlgorithm.Core.MazeMap.Model;

namespace PassingMazesAlgorithm.Core.Reader
{
    public class MapFileReader
    {
        public MapFileReader(string file)
        {
            if (string.IsNullOrEmpty(file))
            {
                throw new ArgumentException("File is not defined");
            }

            if (!File.Exists(file))
            {
                throw new FileNotFoundException("Las file does not found", file);
            }

            _mFileName = file;
        }

        private readonly string _mFileName;
        private MapReader _mapReader = new MapReader();

        public Maze Read()
        {
            var streamReader = new StreamReader(_mFileName);


            return _mapReader.Read(streamReader);
        }
    }
}
