using GraphX.Common.Models;

namespace solution.Graph.Model
{
    public class OptimazedDataEdge : DataEdge
    {
        /// <summary>
        /// Default constructor. We need to set at least Source and Target properties of the edge.
        /// </summary>
        /// <param name="source">Source vertex data</param>
        /// <param name="target">Target vertex data</param>
        /// <param name="weight">Optional edge weight</param>
        public OptimazedDataEdge(DataVertex source, DataVertex target, double weight = 1)
            : base(source, target, weight)
        {
        }
        /// <summary>
        /// Default parameterless constructor (for serialization compatibility)
        /// </summary>
        public OptimazedDataEdge()
            : base(null, null, 1)
        {
        }

        /// <summary>
        /// Custom string property for example
        /// </summary>

        public int Count { set; get; }


        #region GET members
        public override string ToString()
        {
            return Text;
        }

        #endregion
    }
}
