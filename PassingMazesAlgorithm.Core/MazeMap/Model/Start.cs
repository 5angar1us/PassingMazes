using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core
{
    public class Start : MapObject
    {
        public Start(int i) : base('S', i)
        {
        }

        public Start() : base('S')
        {
        }
    }
}
