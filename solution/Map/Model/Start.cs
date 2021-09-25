using solution.GameMap.Model.MapObjects;

namespace solution
{
    class Start : MapObject
    {
        public Start(int i) : base('S', i)
        {
        }

        public Start() : base('S')
        {
        }
    }
}
