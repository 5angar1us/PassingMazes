using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;

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
