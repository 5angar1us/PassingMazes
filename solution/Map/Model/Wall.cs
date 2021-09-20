using solution.Map.Model.MapObjects;

namespace solution
{
    class Wall : MapObject
    {
        public Wall(int i) : base('X', i)
        {
        }

        public Wall() : base('X')
        {
        }
    }
}
