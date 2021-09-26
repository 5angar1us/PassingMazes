using solution.GameMap.Model.MapObjects;

namespace solution
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
