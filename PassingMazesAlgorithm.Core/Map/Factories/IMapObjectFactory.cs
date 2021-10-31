using PassingMazesAlgorithm.Core.GameMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core.GameMap
{
    public interface IMapObjectFactory
    {
        public MapObject CreateObject();
    }
}
