using solution.GameMap.Model.MapObjects;

namespace solution.GameMap
{
    public interface IMapObjectFactory
    {
        public MapObject CreateObject();
    }
}
