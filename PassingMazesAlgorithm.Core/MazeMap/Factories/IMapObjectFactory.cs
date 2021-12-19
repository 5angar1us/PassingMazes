using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core.MazeMap.Factories
{
    public interface IMapObjectFactory
    {
        public MapObject CreateObject();
    }
}
