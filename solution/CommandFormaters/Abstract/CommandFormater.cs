using solution.Graph.Model;
using System.Collections.Generic;
using System.Text;

namespace solution
{
    public abstract class CommandFormater <TEdge>
        where TEdge : DataEdge
    {
        protected static Dictionary<ENeighborSide, string> pairs = new Dictionary<ENeighborSide, string>();

        protected CommandFormater()
        {
            pairs.Add(ENeighborSide.Left, "L");
            pairs.Add(ENeighborSide.Top, "U");
            pairs.Add(ENeighborSide.Right, "R");
            pairs.Add(ENeighborSide.Bottom, "D");
        }

        public virtual void Format(StringBuilder sb, TEdge edge)
        {
            
        }
       

       
    }
}
