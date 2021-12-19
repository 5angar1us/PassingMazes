using PassingMazesAlgorithm.Core.MazeMap.Model.MapObjects;

namespace PassingMazesAlgorithm.Core
{
    public class Quit : MapObject
    {
        public Quit(int i) : base('Q', i)
        {
        }

        public Quit() : base('Q')
        {
        }
    }
}
