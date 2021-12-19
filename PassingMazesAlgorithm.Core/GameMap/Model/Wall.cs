using PassingMazesAlgorithm.Core.GameMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core
{
    public class Wall : MapObject
    {
        public Wall(int i) : base('X', i)
        {
        }

        public Wall() : base('X')
        {
        }
    }
}
