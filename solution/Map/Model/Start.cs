using solution.GameMap.Model.MapObjects;

namespace solution
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
