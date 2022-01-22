using GraphX.Common.Models;
using PassingMazesAlgorithm.Core.NearestIndicesConverters;

namespace PassingMazesAlgorithm.Core.Graph.Model
{
    public class DataEdge : EdgeBase<DataVertex>
    {
        public DataEdge(DataVertex source, DataVertex target, ENeighborSide neighborSide, double weight = 1)
            : base(source, target, weight)
        {
            NeighborSide = neighborSide;
        }

        public DataEdge()
            : base(null, null, 1)
        {
        }
        public ENeighborSide NeighborSide { get; }


        public override string ToString()
        {
            return $"{Source.Name}->{Target.Name}";
        }
    }
}
