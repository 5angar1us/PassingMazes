namespace PassingMazesAlgorithm.Core.Graph.Model
{
    public class OptimazedDataEdge : DataEdge
    {
        public OptimazedDataEdge(DataVertex source, DataVertex target, double weight = 1)
            : base(source, target, weight)
        {
        }

        public OptimazedDataEdge()
            : base(null, null, 1)
        {
        }

        public int Count { set; get; }

        
        public override string ToString()
        {
            return Text;
        }
       
    }
}
